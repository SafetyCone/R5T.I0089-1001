using System;

using R5T.D1001;
using R5T.T0062;
using R5T.T0063;


namespace R5T.I0089_1001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HostStartupBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<TWebHostStartup> AddWebHostStartupAction<TWebHostStartup>(this IServiceAction _,
            IServiceAction<IServiceY> serviceYAction)
            where TWebHostStartup : WebHostStartupBase
        {
            var serviceAction = _.New<TWebHostStartup>(services => services.AddWebHostStartup<TWebHostStartup>(
                serviceYAction));

            return serviceAction;
        }
    }
}
