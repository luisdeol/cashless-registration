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
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using CashlessRegistration.Infrastructure.Persistence;
using CashlessRegistration.Infrastructure.Persistence.Repositories;
using CashlessRegistration.Core.Repositories;
using CashlessRegistration.Core.DomainServices;
using CashlessRegistration.Application.Services;
using System.Reflection;
using System.IO;

namespace CashlessRegistration.API
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
            services.AddDbContext<CashlessRegistrationDbContext>(options => options.UseInMemoryDatabase("CashlessRegistration"));

            services.AddScoped<ICustomerCardRepository, CustomerCardRepository>();

            services.AddScoped<ITokenDomainService, TokenDomainService>();
            services.AddScoped<ICustomerCardService, CustomerCardService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "CashlessRegistration.API", 
                    Version = "v1",
                    Contact = new OpenApiContact {
                        Name = "Luis Felipe",
                        Email = "luisfelipekai@gmail.com",
                        Url = new Uri("https://luisdev.com.br")
                    }});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CashlessRegistration.API v1"));
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
