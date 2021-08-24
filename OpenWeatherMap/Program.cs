using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter API key?");
            var apiKey = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("What city are you in?");
                var city = Console.ReadLine();

                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";

                var weatherResponse = client.GetStringAsync(weatherURL).Result;
                var userResponse = JObject.Parse(weatherResponse).GetValue("main").ToString();
                Console.WriteLine($"{userResponse}");
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city?");
                var answer = Console.ReadLine();

                if (answer.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}
