using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace ProductTracking.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithExceptionDetails()
                .Enrich.WithThreadId()
                .Enrich.WithProcessId()
                    .MinimumLevel.Error()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day,
                        outputTemplate: "[Serilog] {Timestamp:yyyy-MM-dd hh:mm:ss} ({ThreadId}) (ProcId - {ProcessId}) [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
