using System;
using Newtonsoft.Json;
using System.Text.Encodings.Web;

namespace MyDotNetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new { Name = "John Doe", Age = 30 };
            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine($"Hello World! Here's a person in JSON: {json}");

            // Using System.Text.Encodings.Web
            var encoder = HtmlEncoder.Default;
            string htmlEncodedString = encoder.Encode("<script>alert('Hello World');</script>");
            Console.WriteLine($"HTML Encoded String: {htmlEncodedString}");
        }
    }
}

