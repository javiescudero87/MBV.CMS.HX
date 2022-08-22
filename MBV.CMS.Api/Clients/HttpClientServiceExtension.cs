using Correlate.DependencyInjection;

namespace MBV.CMS.Api.Clients
{
    /// <summary>
    /// HttpClientService Extension for Service Injection
    /// </summary>
    public static class HttpClientServiceExtension
    {
        /// <summary>
        /// Main Http Configuration Injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddHttpClientConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient("cmsClient", (s, c) =>
                {
                    c.BaseAddress = new Uri("someUri");
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .AddHeaderPropagation()
                .CorrelateRequests();

        }
    }
}
