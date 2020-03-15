using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.Extensions.Options;
using AutoMapper;
using System;
using Hangfire;
using Hangfire.MySql.Core;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace amusinghoS
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
            services.AddHangfire(config =>
                {
                    config.UseStorage(new MySqlStorage("Server=39.104.53.29; uid = zaranet; pwd = 123456; database = amusinghoS;AllowUserVariables=True;    "));
                });
            //注入工作单元
            services.AddDbContext<amusinghoSDbContext>(options => options.UseMySql(DESEncryptHelper.Decrypt(
                    "wHMoKdCHCsMzxDTTN9+KOGSDC4JDdwxpukgfD+OGDS6W10AAz9lZac3QctGhAr+o1KGJbkuCLwdT4DXj/EM6eLnLKeVRATxDh21b0Jumpb8="
                , "12345678")));
            services.AddTransient(typeof(UnitOfWork));
            services.AddScoped<IRedisClient, CustomerRedis>();
            var csredis = new CSRedis.CSRedisClient("39.104.53.29:6379,password=zaranet");
            RedisHelper.Initialization(csredis);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,options=> {
                options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
            }).AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,options=> {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "mvc client";
                    options.ClientSecret = "mvc secret";
                    options.SaveTokens = true;
                    options.ResponseType = "code";
                    options.Scope.Clear();
                    options.Scope.Add(OidcConstants.StandardScopes.OpenId);
                    options.Scope.Add(OidcConstants.StandardScopes.Profile);
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseCustomErrorPages();
                 app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCustomErrorPages();
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            RecurringJobExtensions.AddRecurringJobs();
            app.UseAuthentication();
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
