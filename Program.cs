using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// ✅ Register services BEFORE calling `builder.Build()`
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Decision API", Version = "v1" });
});

var app = builder.Build();
var logger = app.Logger;

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Decision API v1"));
}

// Replace with your WeatherAPI key (hardcoded for now, but should be moved to a config file)
string weatherApiKey = "7c18c1a04808451099014748251403";
string weatherApiUrl = $"https://api.weatherapi.com/v1/current.json?q=59.41378,5.268&key={weatherApiKey}";

// HTTP Client
var httpClient = new HttpClient();

// Endpoint to decide work location
app.MapGet("/work-decision", async () =>
{
    try
    {
        var response = await httpClient.GetAsync(weatherApiUrl);

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"\u274C Weather API request failed with status {response.StatusCode}");
            return Results.Problem("Failed to fetch weather data. Please try again later.");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var weatherData = JsonSerializer.Deserialize<WeatherResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (weatherData?.Current?.Condition?.Text == null)
        {
            logger.LogError("\u274C Weather API returned an invalid response.");
            return Results.Problem("Weather API response was invalid.");
        }

        if (weatherData.Current.Condition.Text.Contains("rain", StringComparison.OrdinalIgnoreCase))
        {
            return Results.Ok("\ud83c\udfe0 It's raining! Work from home today.");
        }
        else
        {
            return Results.Ok("\u2705 No rain detected! Go to the office.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError($"\u274C Exception occurred: {ex.Message}");
        return Results.Problem("An error occurred while processing the request.");
    }
});

app.Run();

// Weather API Response Model
public class WeatherResponse
{
    public Location? Location { get; set; }
    public WeatherCurrent? Current { get; set; }
}

public class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
}

public class WeatherCurrent
{
    public WeatherCondition? Condition { get; set; }
    public float Temp_c { get; set; }
    public float Feelslike_c { get; set; }
    public int Humidity { get; set; }
}

public class WeatherCondition
{
    public string? Text { get; set; }
    public string? Icon { get; set; }
    public int Code { get; set; }
}
