using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.App.Extensions;
using amusinghoS.App.Models.amusingConfigModel;
using amusinghoS.EntityData;
using amusinghoS.Redis;
using amusinghoS.Services;
using amusinghoS.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using amusinghoS.App.Models.Dto;

namespace amusinghoS
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.Configure<RequestLocalizationOptions>(opts =>
                {
                    var supportedCultures = new List<CultureInfo>{
                        new CultureInfo("en-US"),
                        new CultureInfo("zh-CN")};
                        opts.SupportedCultures = supportedCultures;
                        opts.SupportedUICultures = supportedCultures; 
                        opts.RequestCultureProviders = new List<IRequestCultureProvider>{
                           new X_DOVERequestCultureProvider()
                        };
                });
            //注入工作单元
            services.AddDbContext<amusinghoSDbContext>(options => options.UseMySql(DESEncryptHelper.Decrypt(
                    "wHMoKdCHCsMzxDTTN9+KOGSDC4JDdwxpukgfD+OGDS6W10AAz9lZac3QctGhAr+o1KGJbkuCLwdT4DXj/EM6eLnLKeVRATxDh21b0Jumpb8="
                , "12345678")));
            services.AddTransient(typeof(UnitOfWork));
            services.AddScoped<IRedisClient, CustomerRedis>();
            //var csredis = new CSRedis.CSRedisClient("127.0.0.1:6379");
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCustomErrorPages();
                // app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCustomErrorPages();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseRequestLocalization(
                options:app.ApplicationServices
                .GetService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
