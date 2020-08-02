using Microsoft.Extensions.DependencyInjection;
using Stream.Domain.Abstract.Adapters;
using Stream.Domain.Abstract.Repositories;
using Stream.Domain.Abstract.Services;
using Stream.Domain.Adapters;
using Stream.Domain.Domain;
using Stream.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.API
{
    public static class ServicesRegister
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAudioStreamService, YtAudioStreamService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAudioStreamRepository, YtAudioStreamRepository>();

            return services;
        }

        public static IServiceCollection RegisterHelpers(this IServiceCollection services)
        {
            services.AddSingleton<IYtExplodeAdapter, YtExplodeAdapter>();

            return services;
        }
    }
}
