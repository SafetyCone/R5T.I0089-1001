using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D1001;
using R5T.T0063;


namespace R5T.I0089_1001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HostStartupBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddWebHostStartup<TWebHostStartup>(this IServiceCollection services,
            IServiceAction<IServiceY> serviceYAction)
            where TWebHostStartup : WebHostStartupBase
        {
            services.AddSingleton<TWebHostStartup>()
                .Run(serviceYAction)
                ;

            return services;
        }
    }
}
