using System;
using Newtonsoft.Json;

namespace MyDotNetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new { Name = "John Doe", Age = 30 };
            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine($"Hello World! Here's a person in JSON: {json}");
        }
    }
}
