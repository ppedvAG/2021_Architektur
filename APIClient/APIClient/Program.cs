// See https://aka.ms/new-console-template for more information
using APIClient;

Console.WriteLine("Hello, World!");


var client = new swaggerClient("https://localhost:7163/", new HttpClient());

var www = client.GetWeatherForecastAsync().Result;
foreach (var item in www)
{
    Console.WriteLine(item.Summary);
}