pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'dotnet publish RandomQuotes.sln --output published-app --configuration Release'
      }
    }

    stage('Run Tests') {
      steps {
        sh 'dotnet test RandomQuotes.sln --logger "trx;LogFileName=TestResults.trx"'
      }
    }

    stage('Package') {
        sh 'dotnet-octo pack --id RandomQuotes --version ${currentBuild.number} --basePath /published-app'
    }
    
   

  }
}