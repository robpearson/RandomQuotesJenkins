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
        step ([$class: 'MSTestPublisher', testResultsFile:"**/TestResults/TestResults.trx", failOnError: true, keepLongStdio: true])
      }
    }

  }
}