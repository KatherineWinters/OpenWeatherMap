using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMap_Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("What is your API Key for the location you would like to use?");
            var api_key = Console.ReadLine();

            Console.WriteLine("What is your current city?");
            var city_name = Console.ReadLine();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";

            var response = client.GetStringAsync(weatherURL).Result;

            var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

            Console.WriteLine($"The temp is {JObject.Parse(formattedResponse).GetValue("temp")} outside.");
        }
    }
}
