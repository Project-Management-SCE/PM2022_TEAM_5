pipeline {
       agent none
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        tools = "tmp/DOTNET_CLI_HOME/.dotnet/tools"    
        }
    triggers {
    	 pollSCM 'H * * * *'
        githubPush()
    }
    stages {                      
        stage('Restore, Clean, Build and Test'){                 
               agent{
                      docker{                                                       
                             image 'mcr.microsoft.com/dotnet/sdk:6.0'
                             args '-u root'

                      }  
                      // dockerfile true                    
               }                        
               stages{ 
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
                             sh 'dotnet build ./WebApplication1/WebApplication1.sln --no-restore --configuration Release'
                          }
                       }
                    //  stage('Test: Unit Test'){      
                    //      steps {
                    //           sh 'dotnet test ./WebApplication1/unitTest/unitTest.csproj --configuration Release --no-restore'
                    //        }
                    //     }
                     
	                //    stage('Automation'){	                   					               
	                //         steps {                   			                               
	                //               sh 'dotnet test ./WebApplication1/Automation/Automation.csproj'
		            //            }
	                //    }
                       stage('Coverage Test'){	                   					               
	                        steps {                   			                               
	                              sh 'dotnet tool install -g coverlet.console'
	                            //   sh 'coverlet ./WebApplication1/unitTest/bin/Debug/net5.0/unitTest.dll --target "dotnet" --targetargs "test --no-build" --exclude "[*]WebApplication1*"'
                              sh 'dotnet test ./WebApplication1/unitTest/unitTest.csproj --configuration Release --no-restore /p:CollectCoverage=true /p:CoverletOutput="../coverage.json" /p:MergeWith="../coverage.json" /maxcpucount:1 '
		                       }
	                   }
                       
   
               }
        }          
        stage('Deploy to Heroku') { 
               agent{
                      docker{
                            image 'cimg/base:stable'
                             args '-u root'
                      }
               }
           steps {
               sh '''   			   
                   curl https://cli-assets.heroku.com/install.sh | sh;
                   heroku container:login
                   heroku container:push web --app sportapisce
                   heroku container:release web --app sportapisce
               '''
           }
       }
/* image 'mcr.microsoft.com/dotnet/sdk:5.0'*/
// Google Chrome 91.0.4472.77 
    }
}
