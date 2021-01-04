using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProduct.Configs;
using ApiProduct.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ApiProduct
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
            // database initial - start
            services.Configure<MarketplaceDatabaseSettings>(
                Configuration.GetSection(nameof(MarketplaceDatabaseSettings)));

            services.AddSingleton<IMarketplaceDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MarketplaceDatabaseSettings>>().Value);
            // database initial - end
            
            services.AddControllers();
            
            //add by nanda - start
            
            //remove field in json when value is null
            services.AddMvc()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
            
            //add dependency injection
            //if you usually use spring dependency injection,
            //this place you have to add you bean
            services.AddTransient<IProductService, ProductService>();
            
            //swagger description
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Product API",
                    Description = ".net Core Web API - Product",
                    // TermsOfService = new Uri("https://github.com/nandx"),
                    Contact = new OpenApiContact
                    {
                        Name = "Nanda",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/nandx"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GNU General Public License (GPL)",
                        Url = new Uri("https://github.com/nandx"),
                    }
                });
            });
            
            //add by nanda - end

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            });

            loggerFactory.AddLog4Net();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
        }
    }
}