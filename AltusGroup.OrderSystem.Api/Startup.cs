#region Namespace imports

using System;
using System.IO;
using System.Reflection;
using AltusGroup.OrderSystem.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace AltusGroup.OrderSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Private Fields

        private const string CorsOrigin = "_origins";

        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy(CorsOrigin, builder => builder.WithOrigins("http://localhost:4200", "https://localhost:6671").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services
                 .ConfigureDbContext()
                 .ConfigureRepositories()
                 .AddCustomSwagger();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(CorsOrigin);
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AltusGroup.OrderSystem.Api v1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedData(app.ApplicationServices);
        }

        private void SeedData(IServiceProvider serviceProvider)
        {
            var ordersFile = "AltusGroup.OrderSystem.Api.Orders.json";
            var orderDetailsFile = "AltusGroup.OrderSystem.Api.OrderDetails.json";
            var orderData = GetResourceData(ordersFile);
            var orderDetailsData = GetResourceData(orderDetailsFile);


            OrderSeeder.Seed(orderData, orderDetailsData, serviceProvider);
        }

        private string GetResourceData(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);

            var data = reader.ReadToEnd(); 

            return data;
        }
    }
}
