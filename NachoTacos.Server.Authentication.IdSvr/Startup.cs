using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NachoTacos.Server.Authentication.IdSvr.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NachoTacos.Server.Authentication.IdSvr
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string pfxFilePath = _configuration.GetValue<string>("SignInCredentials:PFXFile");
            string pfxFilePass = _configuration.GetValue<string>("SignInCredentials:Password");

            services.AddIdentityServer()
                    .AddSigningCredential(new X509Certificate2(pfxFilePath, pfxFilePass))
                    .AddTestUsers(InMemoryConfiguration.TestUsers().ToList())
                    .AddInMemoryClients(InMemoryConfiguration.Clients())
                    .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
