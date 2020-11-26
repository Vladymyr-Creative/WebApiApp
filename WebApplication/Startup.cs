using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using WebApplication.Data;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Repositories;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBankLoan, BankLoanRepository>();
            services.AddTransient<ICustomer, CustomerRepository>();
            services.AddTransient<ICarOrder, CarOrderRepository>();
            services.AddTransient<ICarVariant, CarVariantRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            // order is vital, this *must* be called *after* AddNewtonsoftJson()
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });
                c.AddSecurityDefinition("ApiKey",
                    new OpenApiSecurityScheme {
                        Description = "ApiKey Authorization header.",
                        Type = SecuritySchemeType.ApiKey,
                        Name = "x-api-key",
                        In = ParameterLocation.Header
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "ApiKey",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();


            app.UseSwaggerUI();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope()) {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
