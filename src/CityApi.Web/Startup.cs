using AutoMapper;
using CityApi.Infrastructure.External;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using CityApi.Core;
using CityApi.Data;

namespace CityApi.Web
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
            //var connection = @"Server=.;Database=CityApiDb;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<CityDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<CityDbContext>(options => options.UseInMemoryDatabase("CityApiDb"));

            services.AddAutoMapper(typeof(CityMapperProfile));

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddHttpClient<ICountryServiceClient, CountryServiceClient>(client => client.BaseAddress = new Uri("https://restcountries.eu/rest/v2/name"));
            services.AddHttpClient<IWeatherServiceClient, WeatherServiceClient>(client => client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather"));

            services.AddControllers();
            services.AddLogging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
