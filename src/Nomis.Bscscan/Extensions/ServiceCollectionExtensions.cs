using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.Bscscan.Interfaces;
using Nomis.Bscscan.Interfaces.Settings;
using Nomis.Utils.Extensions;

namespace Nomis.Bscscan.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Bscscan service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddBscscanService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<BscscanSettings>(configuration);

            return services
                .AddTransient<IBscscanClient, BscscanClient>()
                .AddTransientInfrastructureService<IBscscanService, BscscanService>();
        }
    }
}