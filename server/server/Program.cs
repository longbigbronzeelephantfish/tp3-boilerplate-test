using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Server
{
    /// <summary>
    /// Class that contains the main function.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that gets called when starting the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        static IWebHost BuildWebHost(string[] args)
        {
            // Check if the environment variable has been set.
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // If not set
            if (string.IsNullOrEmpty(env))
            {
                // Set the default environment to development.
                env = "Development";
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", env);
            }

            // Get the Kestrel web server configuration.
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .AddJsonFile($"hosting.{env}.json", optional: true)
                .Build();

            // Create the web server.
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
