using Airports.WebHost.Domain.Airports;
using Airports.WebHost.Domain.Infrastructure;
using Airports.WebHost.Middlewares.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Airports.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog((ctxt, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(ctxt.Configuration));                

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            WebApplication app = builder.Build();
            
            startup.Configure(app, app.Environment, app.Logger);

            //ILogger _logger = app.Services.GetRequiredService<ILogger<Program>>();

            //using ILoggerFactory loggerFactory = new LoggerFactory();
            //ILogger _logger = loggerFactory.CreateLogger("ApplicationStartingPoint");

            try
            {
                Log.Information("The application has started");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Application hasn`t started due to the unknown internal mistake");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}

