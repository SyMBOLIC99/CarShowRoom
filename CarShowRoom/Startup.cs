using CarShowRoom.BL.Interfaces;
using CarShowRoom.BL.Services;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.DL.Repositories.InMemoryRepos;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CarShowRoom
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
            services.AddSingleton(Log.Logger);
            services.AddAutoMapper(typeof(Startup));


            services.AddSingleton<ICarRepository, CarInMemoryRepository>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IShiftRepository, ShiftInMemoryRepository>();
            services.AddSingleton<IShiftService, ShiftService>();
            services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton <IClientService, ClientService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
          
            services.AddControllers();
            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarShowRoom", Version = "v1" });
               });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarShowRoom v1"));
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
