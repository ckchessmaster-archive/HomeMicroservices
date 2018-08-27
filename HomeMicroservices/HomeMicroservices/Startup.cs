using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeMicroservices
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Required authentication service and options
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options =>
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();

            // Required MVC service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Show helpful debug info
                app.UseDeveloperExceptionPage();
            }

            // Force all pages to https
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            // We want to use authentication for anything following this middleware
            app.UseAuthentication();

            // Use MVC routing
            app.UseMvc(ConfigureRoutes);

            // If no route is found we end up here
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("404 Not Found!");
            });
        }

        /// <summary>
        /// Setup MVC routes
        /// </summary>
        /// <param name="routeBuilder"></param>
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}");
        }
    }
}
