using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIComponents.Utils;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stream.Domain.Abstract.Repositories;
using Stream.Domain.Abstract.Services;
using Stream.Domain.Domain;
using Stream.Infrastructure.Services;

namespace Stream.API
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
            services.AddSingleton<ILogger, ActionFilterLogger>();
            services.AddTransient<IAudioStreamService, YtAudioStreamService>();
            services.AddTransient<IAudioStreamRepository, YtAudioStreamRepository>();

            #region external

            services.AddNodeJS();

            #endregion


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
