pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:6.0'
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
                sh 'dotnet test ./WebApplication1/unitTest/unitTest.csproj --configuration Release --no-restore'
             }
          }
    }
}
