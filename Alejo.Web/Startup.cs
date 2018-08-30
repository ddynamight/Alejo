using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alejo.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alejo.Data.Repository;
using System.Security.Claims;

namespace Alejo.Web
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
               services.Configure<CookiePolicyOptions>(options =>
               {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
               });

               services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));
               services.AddDefaultIdentity<AppUser>()
                   .AddEntityFrameworkStores<AppDbContext>();

               services.AddIdentity<AppUser, IdentityRole>(options =>
               {
                    // Lockout Settings
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // Sign In Settings
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    // Password Settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
               })
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

               services.AddTransient<IUserRepository, UserRepository>();

               services.AddDistributedMemoryCache();

               services.AddSession(options => {
                    options.IdleTimeout = TimeSpan.FromMinutes(1);
                    options.IOTimeout = TimeSpan.FromMinutes(1);
                    options.Cookie.HttpOnly = true;
               });

               services.AddMvc()
                   .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                   .AddSessionStateTempDataProvider();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager,
               RoleManager<IdentityRole> roleManager)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
               }
               else
               {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
               }

               DbInitialize.SeedData(userManager, roleManager);

               app.UseHttpsRedirection();
               app.UseStaticFiles();
               app.UseSession();
               app.UseAuthentication();

               app.UseMvc(routes =>
               {
                    routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                    routes.MapRoute(
                     name: "default",
                     template: "{controller=Home}/{action=Index}/{id?}");
               });
               app.UseCookiePolicy();
          }
     }
}
