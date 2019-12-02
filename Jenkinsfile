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
            sh "/opt/Octo/Octo pack --id RandomQuotes --version 1.6.${env.BUILD_NUMBER} --format=Zip --basePath RandomQuotes/published-app"
        }
    }
    
     stage ('Push to Octopus') {
        steps {
            sh "/opt/Octo/Octo push --package=RandomQuotes.1.6.${env.BUILD_NUMBER}.zip  --replace-existing --server=https://demo.octopus.app/ --apiKey=API-LK0QPLVD6ZIHJ3NPEJQRMBBDYM"  
        }
     }

     stage ('Create release') {
        steps {
            sh "/opt/Octo/Octo create-release --project='Random Quotes' --releaseNumber 1.6.${env.BUILD_NUMBER} --server=https://demo.octopus.app/ --apiKey=API-LK0QPLVD6ZIHJ3NPEJQRMBBDYM"  
        }
     }
    
  }
}