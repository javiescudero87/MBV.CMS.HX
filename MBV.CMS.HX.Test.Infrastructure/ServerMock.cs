using MBV.CMS.HX.DataAccess.NHibernate.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace MBV.CMS.HX.Test.Infrastructure
{
    public class ServerMock : IDisposable
    {
        public ISession Session { get; }
        public IConfigurationRoot? Configuration { get; private set; }
        public string PortMock { get; set; } = string.Empty;
        public string UrlHostMock { get; set; } = string.Empty;
        public TestServer? TestServer { get; }


        public ServerMock()
        {
            try
            {
                var webApplicationFactory = CreateWebApplicationFactory();
                var scope = webApplicationFactory.Server.Services.CreateScope();
                var services = scope.ServiceProvider;

                TestServer = webApplicationFactory.Server;

                Session = services.GetRequiredService<ISession>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
        }

        private WebApplicationFactory<Program> CreateWebApplicationFactory()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            var con = Configuration["ConnectionStrings:DefaultConnection"];
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, conf) =>
                    {
                        conf.AddConfiguration(Configuration);
                    });

                    //builder.ConfigureTestServices(services =>
                    //{
                    //    var sessionDescriptor = services.SingleOrDefault(d =>
                    //        d.ServiceType == typeof(ISession));

                    //    if (sessionDescriptor != null)
                    //        services.Remove(sessionDescriptor);

                    //    var sessionFactoryDescriptor = services.SingleOrDefault(d =>
                    //        d.ServiceType == typeof(ISessionFactory));

                    //    if (sessionFactoryDescriptor != null)
                    //        services.Remove(sessionFactoryDescriptor);
                    //    services.AddNHibernate(con, true);

                    //});
                });

            FillConfiguration();

            return application;
        }

        private void FillConfiguration()
        {
            PortMock = Configuration.GetValue<string>("PortMock");
            UrlHostMock = Configuration.GetValue<string>("UrlHostMock");
        }
    }
}
