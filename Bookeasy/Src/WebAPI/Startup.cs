using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookeasy.Application;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Infrastructure;
using Bookeasy.Persistence;
using Bookeasy.WebUI.Common;
using Bookeasy.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHealthChecks()
                .AddDbContextCheck<NorthwindDbContext>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();
            
            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<INorthwindDbContext>());;
            
            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Northwind Traders API";
            });
            
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            
            app.UseOpenApi();

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                //    settings.DocumentPath = "/api/specification.json";   Enable when NSwag.MSBuild is upgraded to .NET Core 3.0
            });

            app.UseRouting();

            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}