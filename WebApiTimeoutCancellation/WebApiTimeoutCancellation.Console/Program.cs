// See https://aka.ms/new-console-template for more information


Console.WriteLine("Fetching data ...");
HttpClient client = new HttpClient();
client.Timeout = TimeSpan.FromSeconds(6);
var result = await client.GetStringAsync("https://localhost:7281/WeatherForecast");
Console.WriteLine(result);


