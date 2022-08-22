using MBV.CMS.Domain;
using System.Diagnostics;

namespace MBV.CMS.Test.Infrastructure
{
    public class ServerFixture : IDisposable
    {
        public ServerFixture()
        {
            Debug.Write("ServerFixture Constructor - It execute once before integration test execution.");

            HttpServer = new ServerMock();
            WireMock = new WireMockHelper(HttpServer.UrlHostMock, HttpServer.PortMock);
        }

        public void CleanDatabase()
        {
            HttpServer.Session.CreateQuery($"delete from {nameof(ExampleEntity)}").ExecuteUpdate();
        }

        public ServerMock HttpServer { get; }

        public WireMockHelper WireMock { get; set; }

        public void Dispose()
        {
            Debug.Write("Disposes only once per test.");
            WireMock.Stop();
            WireMock.Dispose();
            HttpServer.Dispose();
        }
    }
}