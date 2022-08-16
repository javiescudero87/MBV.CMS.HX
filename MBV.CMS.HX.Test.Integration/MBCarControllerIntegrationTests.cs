using MBV.CMS.HX.Api.ViewModels;
using MBV.CMS.HX.Domain;
using MBV.CMS.HX.Test.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MBV.CMS.HX.Test.Integration
{
    [Collection(ServerFixtureCollection.Name)]
    public class MBCarControllerIntegrationTests
    {
        private readonly ServerFixture _server;
        private const string BaseAddress = "/api/v1/mercedes-benz-cars";

        public MBCarControllerIntegrationTests(ServerFixture server)
        {
            _server = server;
            _server.CleanDatabase();
        }

        [Fact]
        public async Task GetMBCar_ShouldReturnOk()
        {
            //Arrange
            var expectedName = "Sprinter XYZ";
            long expectedId = AddMBCarToDb(expectedName);

            //Act
            var server = _server.HttpServer.TestServer;
            var client = server?.CreateClient();
            var response = await client.GetAsync(GetMBCarUri(expectedId.ToString()));

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var mBCarResponse = await response.Content.ReadAsAsync<MBCarResponse>();
            Assert.Equal(expectedId, mBCarResponse.Id);
            Assert.Equal(expectedName, mBCarResponse.Name);
        }

        private long AddMBCarToDb(string name)
        {
            return (long)_server.HttpServer.Session.Save(new MBCar { Name = name });
        }

        private string GetMBCarUri(string id)
        {
            return $"{BaseAddress}/{id}";
        }
    }
}