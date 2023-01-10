using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AirlineUI.Services;
using FluentValidation;
using AirlineUI.Validation;
using System.Net.Http;

namespace AirlineUI
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
            
    
            services.AddScoped(client =>
            new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44383")
            });
            services.AddHttpClient();

            services.AddScoped<FlightScheduleService>();
            services.AddScoped<FlightService>();
            services.AddScoped<PassengerService>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddValidatorsFromAssemblyContaining<PassengerViewModelValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
