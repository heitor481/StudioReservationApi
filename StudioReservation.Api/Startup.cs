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
using Newtonsoft.Json;
using StudioReservation.NewDomain.ViewModel;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace StudioReservation.Api
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
            services.AddControllers().AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            services.AddDbContext<StudioReservationContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")));

            #region JWT Token
                var appSettingsSection = Configuration.GetSection("AppSettings");
                services.Configure<AppSettings>(appSettingsSection);

                var appSettings = appSettingsSection.Get<AppSettings>();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);

                services.AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(options => {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            #endregion
            
            #region DI
                services.AddTransient<StudioReservationContext>();
                services.AddScoped<ILoginMiddleware, LoginMiddleware>();
                services.AddScoped<IStudioMiddleware, StudioMiddleware>();
                services.AddScoped<IReservationMiddleware, ReservationMiddleware>();
                services.AddScoped<ILoginRepository, LoginRepository>();
                services.AddScoped<IStudioRepository, StudioRepository>();
                services.AddScoped<IReservationRepository, ReservationRepository>();
            #endregion
                   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

             app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
