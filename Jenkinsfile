pipeline {
  environment {
    MSBUILD = "C:/Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin"
    CONFIG = 'Release'
    PLATFORM = 'x64'
  }
  stages {
    stage('Build') {
      steps {
        bat "NuGet.exe restore your_project.sln"
        bat "\"${MSBUILD}\" your_project.sln /p:Configuration=${env.CONFIG};Platform=${env.PLATFORM} /maxcpucount:%NUMBER_OF_PROCESSORS% /nodeReuse:false"
      }
    }
  }
}
