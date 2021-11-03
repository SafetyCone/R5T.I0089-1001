using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.D0089;
using R5T.D1001;
using R5T.D1001.A001;


namespace R5T.I0089_1001
{
    public abstract class WebHostStartupBase : IWebHostStartup
    {
        protected IServiceY ServiceY { get; }


        public WebHostStartupBase(
            IServiceY serviceY)
        {
            this.ServiceY = serviceY;
        }

        public async Task ConfigureApplication(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine($"In {nameof(WebHostStartupBase)}.{nameof(ConfigureApplication)}.");

            await this.ServiceY.RunY();

            // Now setup basic "hello world" functionality.
            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            await this.AdditionalConfigureApplication(applicationBuilder);
        }

        protected abstract Task AdditionalConfigureApplication(IApplicationBuilder applicationBuilder);

        public abstract Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder);

        public async Task ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine($"In {nameof(WebHostStartupBase)}.{nameof(ConfigureServices)}.");

            await this.ServiceY.RunY();

            var serviceZActionAggregation = Instances.ServiceAction.AddServiceZActionAggregation();

            await this.AdditionalConfigureServices(services, serviceZActionAggregation);
        }

        protected abstract Task AdditionalConfigureServices(IServiceCollection services,
            IServiceZActionAggregation serviceZActionAggregation);
    }
}
