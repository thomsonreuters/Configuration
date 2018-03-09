using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddContainerSecrets("/etc/foo", false);

            var config = builder.Build();
            Console.WriteLine(config["password"]);
            return 0;
        }
    }
}
