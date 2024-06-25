using System;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using Halibut;
using Halibut.Transport;
using Halibut.Transport.Protocol;
using Wire;
using System.Security.Cryptography.Xml;
using QuantConnect;

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

            // Using Halibut
            var endpoint = new ServiceEndPoint(new Uri("https://example.com"), "thumbprint");
            Console.WriteLine($"Halibut Endpoint URI: {endpoint.BaseUri}");

            // Using Wire
            var serializer = new Serializer();
            var serializedPerson = serializer.Serialize(person);
            Console.WriteLine($"Serialized Person using Wire: {Convert.ToBase64String(serializedPerson)}");

            // Using System.Security.Cryptography.Xml
            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.LoadXml("<root><test>Example</test></root>");
            var signedXml = new SignedXml(xmlDocument);
            Console.WriteLine($"XML Document: {xmlDocument.OuterXml}");

            // Using QuantConnect.Common
            var qcUser = new QuantConnect.Api.Api();
            Console.WriteLine("QuantConnect API User Created");
        }
    }
}


