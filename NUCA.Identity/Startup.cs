
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUCA.Identity.Core;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System;
using static IdentityServer4.IdentityServerConstants;

namespace NUCA.Identity
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

            services.AddControllersWithViews(configure =>
            {
                // configure.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy));
            }).AddRazorRuntimeCompilation(); ;

            services.AddDbContext<DbContext, ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddUserStore<ApplicationUserStore>()
                    .AddRoles<Role>()
                    .AddDefaultTokenProviders();
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });
            var builder = services.AddIdentityServer(options =>
            {
                options.Cors.CorsPaths = new[]
                {
                     PathString.FromUriComponent(new Uri(Config.FrontendUri))
                };

                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
              .AddInMemoryIdentityResources(Config.IdentityResources)
              .AddInMemoryApiResources(Config.ApiResources)
              .AddInMemoryApiScopes(Config.ApiScopes)
              .AddInMemoryClients(Config.Clients)
              .AddAspNetIdentity<User>()
              .AddProfileService<ProfileService>();



            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(Config.FrontendUri)
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddLocalApiAuthentication();
            /* services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
             {
                 //options.Authority = "https://localhost:5010";
                 options.Audience = "identity";
                / options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = true,
                     ValidateIssuer = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                 };
             });*/
            services.AddAuthorization(options =>
            {
                options.AddPolicy(LocalApi.PolicyName, policy =>
                {
                    policy.AddAuthenticationSchemes(LocalApi.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(Role.Admin.Name);
                });
            });

        }

        public void Configure(IApplicationBuilder app)
        {

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseCors("CorsPolicy");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}