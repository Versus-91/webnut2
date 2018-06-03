using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DataSystem.Data;
using DataSystem.Models;
using DataTables.AspNet.AspNetCore;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace DataSystem
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

        var serviceCollection = new ServiceCollection();
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<WebNutContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // services.Configure<WebNutContext>(Configuration.GetSection("DefaultConnection"));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.Cookies.ApplicationCookie.SlidingExpiration = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAntiforgery(options => options.HeaderName = "csrftoken");

            services.AddMvc();
            services.AddMemoryCache();
            // services.AddDataProtection().ProtectKeysWithDpapi().PersistKeysToFileSystem(new DirectoryInfo(@"h:\root\home\webnutdb-001\www\webnut\datakeys\"));
            services.AddDataProtection().ProtectKeysWithDpapi().PersistKeysToFileSystem(new DirectoryInfo(@"C:\DataSystem\DataSystem\datakeys\"));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".thisapp_webnut";
            });
            services.RegisterDataTables();
            services.AddAutoMapper();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                                  policy.RequireClaim("super_admin","1"));
            });           
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, WebNutContext context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

            app.UseStaticFiles();

            app.UseIdentity();
            app.UseSession();
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Checks}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context, _roleManager, _userManager);

        }
    }
}
