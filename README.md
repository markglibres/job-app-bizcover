# job-app-bizcover
A simple programming exercise for BizCover's Car Shop

## Pre-requisites 
* DotNetCore >= 2.2 

## Build, Run and Test API with docker compose
1. Open console 
2. Go to project root folder 
3. execute command to build and unit tests
```
 docker-compose -f .\docker-compose-test.yml build
``` 
4. execute command to spin up api and run integration tests (give some time for tests to complete)
```
 docker-compose -f .\docker-compose-test.yml up
``` 
5. Browse to http://localhost:5000/swagger to see list of APIs

## Build without docker compose
1. Open console 
2. Go to project root folder
3. execute command to build 
```
 dotnet build .\src\BizCover.Api.Cars
``` 
4. execute command to run api 
```
 dotnet run --project .\src\BizCover.Api.Cars\BizCover.Api.Cars.csproj
``` 
5. Browse to http://localhost:5000/swagger to see list of APIs 

## Run unit and integration tests without docker compose
1. Open console 
2. Go to project root folder
3. execute command to run unit tests
```
 dotnet test .\tests\BizCover.Api.Cars.Unit.Tests\
``` 
4. execute command to run integration tests (make sure the api is running from steps above)
```
 dotnet test .\tests\BizCover.Api.Cars.Integration.Tests\
``` 



