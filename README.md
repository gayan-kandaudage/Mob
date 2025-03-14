# 🌤 Mob session

## Install .NET SDK (if not installed):

dotnet --version

## Install Mob Next (for driver rotation)

from [mob.sh](https://mob.sh/)

curl -sL install.mob.sh | sh or npm install -g mob

## Clone repo

git clone git@github.com:gayan-kandaudage/Mob.git

## Weather api
documentation to apis [Documentation]https://www.weatherapi.com/docs/#intro-request
api [WeatherAPI.com](https://app.swaggerhub.com/apis-docs/WeatherAPI.com/WeatherAPI/1.0.2#/APIs/realtime-weather)
api key 7c18c1a04808451099014748251403

## Build project

dotnet restore  # Restores all dependencies
dotnet build    # Builds the project
dotnet run      # Runs the API

## Access api definition

[Swagger]http://localhost:5044/swagger/v1/swagger.json

## Access api

[Work-decision]http://localhost:5044/work-decision