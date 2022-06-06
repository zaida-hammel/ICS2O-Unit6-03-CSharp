// Created by: Zaida Hammel
// Created on: May 2022
//
// This program accepts user input

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5"
        );
        var json = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        JsonNode jsonData = JsonNode.Parse(response)!;
        JsonNode temp = jsonData["main"]["temp"];
        var temperature = (double)temp;
        string celsiusTemp = (temperature - 273.15).ToString("0");

        Console.WriteLine("The current weather is " + celsiusTemp + "°C");
        Console.ReadKey();
        Console.WriteLine("Done");
    }
}