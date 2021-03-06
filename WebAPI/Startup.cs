using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Database;
using WebAPI.Services;
using WebAPI.Services.Farms;
using WebAPI.Services.Measurements;
using WebAPI.Services.PlantKeepers;
using WebAPI.Services.Sensors;
using WebAPI.Services.SensorSettings;

namespace WebAPI
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
            Console.WriteLine("DefaultConnection -> " + Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContextPool<DataContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPI", Version = "v1"}); });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IPlantKeepersService, PlantKeepersService>();
            services.AddScoped<IFarmsService, FarmsService>();
            services.AddScoped<ISensorsService, SensorsService>();
            services.AddScoped<ISensorSettingsService, SensorSettingsService>();
            services.AddScoped<IMeasurementsService, MeasurementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}