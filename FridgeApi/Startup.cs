using FridgeApi.BL;
using FridgeApi.BL.Implementations;
using FridgeApi.BL.Interfaces;
using FridgeApi.BL.Services;
using FridgeApi.DAL;
using FridgeApi.DAL.Implementations;
using FridgeApi.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi
{
    public class Startup
    {
        public static IConfigurationRoot ConfString { get; set; }

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv, IConfiguration configuration)
        {
            ConfString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                    services.AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = true;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ClockSkew = TimeSpan.Zero,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["AppKey"])),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                        };
                    });

            services.AddDbContext<FridgeContext>(options =>
                options.UseSqlServer(ConfString.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddScoped<IFridgeRepository, AllFridges>();
            services.AddScoped<IProductRepository, AllProducts>();
            services.AddScoped<IAllAccount, AllAccounts>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFridgeService, FridgeService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FridgeApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FridgeApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
