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
        steps {
            sh 'dotnet-octo pack --id RandomQuotes --version ${env.BUILD_NUMBER} --basePath RandomQuotes/published-app'
        }
    }
    
  }
}