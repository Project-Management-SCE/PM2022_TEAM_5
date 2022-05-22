pipeline {
       agent none
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        }
    triggers {
    	 pollSCM 'H * * * *'
        githubPush()
    }
    stages {                      
        stage('Restore, Clean, Build and Test'){                 
               agent{
                      docker{                                                       
                             // image 'mcr.microsoft.com/dotnet/sdk:6.0'
                              image 'elgalu/selenium'
                      }  
                      // dockerfile true                    
               }
                                  
               stages{ 
                       stage('Restore packages'){
                         steps{                     
                         	sh 'google-chrome --version'    
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
                     // stage('Test: Unit Test'){      
                     //     steps {
                     //          sh 'dotnet test ./WebApplication1/unitTest/unitTest.csproj --configuration Release --no-restore'
                     //       }
                     //    }
                     
	                   stage('Automation'){	                   		
	       	         //       agent{
		                //       docker{			                             
		                //              image 'elgalu/selenium'
		                //       }
			               // }			               
	                        steps {
	                        		// sh 'google-chrome --version' 	                   			                               
	                              sh 'dotnet test ./WebApplication1/Automation/Automation.csproj'
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
