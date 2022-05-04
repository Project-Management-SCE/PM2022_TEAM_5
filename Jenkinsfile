pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:6.0'
            image 'mcr.microsoft.com/dotnet/core/aspnet'
        }
    }
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        }
    triggers {
    	 pollSCM 'H * * * *'
        githubPush()
    }
    stages {
        stage('Restore packages'){
           steps{
               sh 'dotnet restore ./WebApplication1/WebApplication1.sln'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean ./WebApplication1/WebApplication1.sln --configuration Release'
            }
         }         
        stage('Build'){
           steps{
               sh 'dotnet build ./WebApplication1/WebApplication1.sln --configuration Release --no-restore'
            }
         }        
       stage('Test: Unit Test'){
           steps {
                sh 'dotnet test ./WebApplication1/TestProject1/TestProject1.csproj --configuration Release --no-restore'
             }
          }
          /* 
        stage('Publish'){
             steps{
               sh 'dotnet publish WebApplication/WebApplication.csproj --configuration Release --no-restore'
             }
        }
        stage('Deploy'){
             steps{
               sh '''for pid in $(lsof -t -i:9090); do
                       kill -9 $pid
               done'''
               sh 'cd WebApplication/bin/Release/netcoreapp3.1/publish/'
               sh 'nohup dotnet WebApplication.dll --urls="http://104.128.91.189:9090" --ip="104.128.91.189" --port=9090 --no-restore > /dev/null 2>&1 &'
             }
        }*/
    }
}
