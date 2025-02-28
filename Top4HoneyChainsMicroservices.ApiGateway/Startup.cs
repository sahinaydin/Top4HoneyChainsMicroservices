﻿using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Top4HoneyChainsMicroservices.ApiGateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Gateway",
                    Version = "v1",
                    Description = "API Gateway",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Hasan Kıvrakdal",
                        Email = "hsnkivrakdal@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Employee API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

            });
            services.AddOcelot();
            services.AddControllers();
        }



        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway");
            });

            app.UseRouting();

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOcelot();
        }
    }
}