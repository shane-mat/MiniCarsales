using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiniCarsales.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using MiniCarsales.API.Application.Common.Commands;
using System.Reflection;
using MiniCarsales.API.Application.Cars.Commands;
using MiniCarsales.API.Middlewares;

namespace MiniCarsales.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddCors(opt =>
            {
                opt.AddPolicy("Corspolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            services.AddControllers();
             services.AddDbContext<VehicleContext>(op =>
                op.UseInMemoryDatabase(databaseName: "Vehicles"));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(config =>
            {
                config.CreateMissingTypeMaps = true;
                config.ValidateInlineMaps = false;
                config.AllowNullCollections = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
