using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCarsales.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MiniCarsales.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var svc = scope.ServiceProvider;
                try
                {
                    var ctx = svc.GetRequiredService<VehicleContext>();
                    ctx.Database.Migrate();
                }
                catch(Exception ex)
                {
                    var logger = svc.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
