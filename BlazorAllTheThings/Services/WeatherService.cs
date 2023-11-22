namespace BlazorAllTheThings.Services;

public class WeatherService
{
    public async IAsyncEnumerable<WeatherForecast> GetWeatherAsync()
    {
        // Simulate a long running job
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        foreach (var index in Enumerable.Range(1, 5))
        {
            // Simulate a streamed data response
            await Task.Delay(500);

            yield return new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            };
        }
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
