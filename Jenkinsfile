### Jenkinsfile

```groovy
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                script {
                    bat 'dotnet build'
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    bat 'dotnet test'
                }
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: '**/Screenshots/*.png', allowEmptyArchive: true
            junit '**/TestResults/*.xml'
        }
    }
}