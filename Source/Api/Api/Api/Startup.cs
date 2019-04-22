using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
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

            #region DI

            services.AddScoped<Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddScoped<Repositories.IAuthenticationRepository, Repositories.AuthenticationRepository>();
            services.AddScoped<Services.IFreightService, Services.FreightService>();
            services.AddScoped<Repositories.IFreightRepository, Repositories.FreightRepository>();
            services.AddScoped<Services.ISerasaService, Services.SerasaService>();
            services.AddScoped<Services.ICreditService, Services.CreditService>();
            services.AddScoped<Repositories.ICreditRepository, Repositories.CreditRepository>();


            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<Authorization>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
