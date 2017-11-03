using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Server.Data;
using Server.Seed;
using Server.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using Server.Respositories;
using Server.Respositories.Interfaces;

namespace Server
{
    /// <summary>
    /// This class is in charge of configuring the web server services.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Dependencies will be injected into the constructor.
        /// </summary>
        /// <param name="configuration">Configuration object injected in by the Dependency Injection container</param>
        /// <param name="environment">Environment object injected in by the Dependency Injection container</param>
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container. 
        /// </summary>
        /// <param name="services">Services collection injected in by the Dependency Injection container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<DatabaseContext>(
                (builder) =>
                {
                    if (Environment.IsDevelopment())
                    {
                        // Enable more logging if in development environment.
                        builder.EnableSensitiveDataLogging();
                    }
                    // Read the database host and password from the secrets file.
                    var secrets = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("secrets.json").Build();
                    var connection = $@"server={secrets["host"]};port=3306;database=database;uid=root;pwd={secrets["password"]};";
                    // Configure the database connection.
                    builder.UseMySql(connection);
                }
            );

            // Swagger
            // Enable only in development environment.
            if (Environment.IsDevelopment())
            {
                services.AddSwaggerGen(
                    (options) =>
                    {
                        // Create a document.
                        options.SwaggerDoc("v1", new Info { Title = "API" });
                        // Set the comments path for the Swagger JSON and UI.
                        var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                        var xmlPath = Path.Combine(basePath, "Server.xml");
                        options.IncludeXmlComments(xmlPath);
                    }
                );
            }

            // MVC
            services.AddMvc().AddJsonOptions(
                (options) =>
                {
                    // Configure the JSON serialisation settings.
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
            );

            // Cross-Origin Resource Sharing
            services.AddCors();

            // Register all the Repositories and Services
            services.AddScoped<INotesRepository, NotesRepository>();
        }


        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder injected in by the Dependency Injection container</param>
        /// <param name="context">Database connection injected in by the Dependency Injection container</param>
        public void Configure(IApplicationBuilder app, DatabaseContext context)
        {
            // Database
            if (Configuration.GetSection("DatabaseSeeding").GetValue<Boolean>("SeedDatabase"))
            {
                if (Configuration.GetSection("DatabaseSeeding").GetValue<Boolean>("DeleteDatabaseBeforeSeed"))
                {
                    Console.WriteLine("Deleting database...");
                    context.Database.EnsureDeleted();
                }
                Console.WriteLine("Seeding database...");
                DatabaseSeeder.Seed(context);
                Console.WriteLine($"Database seeded!");
            }
            else
            {
                context.Database.EnsureCreated();
            }
;
            // HTTP Pipeline
            if (Environment.IsDevelopment())
            {
                // Error pages
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                // Debug middleware
                app.UseMiddleware<DebugMiddleware>();
                // Enable Swagger
                app.UseSwagger();
                app.UseSwaggerUI(
                    (options) =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                    }
                );
                // Allow all origins, methods and headers in development
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }

            // MVC
            app.UseMvc();
        }
    }
}
