using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("settings.json");

            var config = builder.Build();

            builder.AddContainerSecrets();

            config = builder.Build();

            Console.WriteLine(config["ConnectionString"]);
        }
    }
}
