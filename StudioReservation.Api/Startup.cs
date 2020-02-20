using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData;
using StudioReservation.NewData.Repository;
using StudioReservation.NewData.Repository.Interfaces;

namespace StudioReservation.Api
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
            services.AddControllers();
            services.AddDbContext<StudioReservationContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")));

            //this is for dependency injection
            services.AddTransient<StudioReservationContext>();
            services.AddScoped<IStudioMiddleware, StudioMiddleware>();
            services.AddScoped<IStudioRepository, StudioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
