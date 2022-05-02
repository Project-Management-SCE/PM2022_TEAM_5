using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;
using WebApplication1;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using WebApplication1.Model;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace TestProject
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        foreach(var service in services)
                        {
                            if(typeof(AuthDbContext) == service.ServiceType)
                            {
                                services.Remove(service);
                            }
                        }
                        services.AddDbContext<AuthDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });
                });
                });
            //TestClient = appFactory.CreateClient();
        }

        //protected async Task AuthenticateAsync()
        //{
        //    TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        //}

        //private async Task<string> GetJwtAsync()
        //{
        //    //var response = TestClient.PostAsJsonAsync(ApiRoutes)
        //}
    }
}
