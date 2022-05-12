pipeline {
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
                        agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:5.0'
                }
            }
           steps{
               sh 'dotnet restore ./WebApplication1/WebApplication1.sln'
            }
         }
        stage('Clean'){
               agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:5.0'
                }
            }
           steps{
               sh 'dotnet clean ./WebApplication1/WebApplication1.sln --configuration Release'
            }
         }         
        stage('Build'){
               agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:5.0'
                }
            }
           steps{
               sh 'dotnet build ./WebApplication1/WebApplication1.sln --configuration Release --no-restore'
            }
         }
       stage('Test: Unit Test'){
              agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:5.0'
                }
            }
           steps {
                sh 'dotnet test ./WebApplication1/unitTest/unitTest.csproj --configuration Release --no-restore'
             }
          }
    }
}
