# 🌤 Mob session

A simple weather forcasting API need bug fixes and enhancements

```json
{
location: "Canada",
region: "Ottawa",
decision: "✅ No rain detected! Go to the office."
}
```

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

## Api response

```json
{
  "location": {
    "name": "Canada",
    "region": "Canada",
    "country": "US",
    "lat": 29.412,
    "lon": 54.278,
    "tz_id": "US/Canada",
    "localtime_epoch": 1741921428,
    "localtime": "2025-03-14 04:03"
  },
  "current": {
    "last_updated_epoch": 1741921200,
    "last_updated": "2025-03-14 04:00",
    "temp_c": 1.7,
    "temp_f": 35.1,
    "is_day": 0,
    "condition": {
      "text": "Cloudy",
      "icon": "//cdn.weatherapi.com/weather/64x64/night/119.png",
      "code": 1006
    },
    "wind_mph": 2.5,
    "wind_kph": 4,
    "wind_degree": 81,
    "wind_dir": "E",
    "pressure_mb": 1005,
    "pressure_in": 29.67,
    "precip_mm": 0,
    "precip_in": 0,
    "humidity": 67,
    "cloud": 72,
    "feelslike_c": 0.9,
    "feelslike_f": 33.6,
    "windchill_c": 0.9,
    "windchill_f": 33.6,
    "heatindex_c": 1.7,
    "heatindex_f": 35.1,
    "dewpoint_c": -3.7,
    "dewpoint_f": 25.3,
    "vis_km": 10,
    "vis_miles": 6,
    "uv": 0,
    "gust_mph": 3.6,
    "gust_kph": 5.8
  }
}
```

## Build project

dotnet restore  # Restores all dependencies
dotnet build    # Builds the project
dotnet run      # Runs the API

## Access api definition

[Swagger]http://localhost:5044/swagger/v1/swagger.json

## Access api

[Work-decision]http://localhost:5044/work-decision
