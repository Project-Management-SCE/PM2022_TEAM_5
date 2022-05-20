FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApplication1/WebApplication1/WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1/WebApplication1.csproj" -c Release -o /app/build

FROM build
run docker pull 'elgalu/selenium' 
run dotnet test "Automation/Automation.csproj"

FROM build AS publish
RUN sudo apt-get update
RUN sudo apt-get upgrade
RUN sudo curl -sSL https://get.docker.com/ | sh
RUN dotnet publish "WebApplication1/WebApplication1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WebApplication1.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication1.dll
