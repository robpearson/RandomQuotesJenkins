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
            sh "/home/parallels/.dotnet/tools/dotnet-octo pack --id RandomQuotes --version 1.6.${env.BUILD_NUMBER} --format=Zip --basePath RandomQuotes/published-app"
        }
    }
    
     stage ('Push to Octopus') {
        steps {
            sh "/home/parallels/.dotnet/tools/dotnet-octo push --package=RandomQuotes.1.6.${env.BUILD_NUMBER}.zip  --replace-existing --server=https://cloud.tentaclearmy.com:8085/ --apiKey=API-AAU863DZOLRUCPQBUFYXRLTF3IQ"  
        }
     }

     stage ('Create release') {
        steps {
            sh "/home/parallels/.dotnet/tools/dotnet-octo create-release --project=Random Quotes -defaultpackageversion --releaseNumber 1.6.${env.BUILD_NUMBER} --server=https://cloud.tentaclearmy.com:8085/ --apiKey=API-AAU863DZOLRUCPQBUFYXRLTF3IQ"  
        }
     }
    
  }
}