using MBV.CMS.Api.ViewModels;
using MBV.CMS.Domain;
using MBV.CMS.Test.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MBV.CMS.Test.Integration
{
    [Collection(ServerFixtureCollection.Name)]
    public class ExampleControllerIntegrationTests
    {
        private readonly ServerFixture _server;
        private const string BaseAddress = "/api/v1/mercedes-benz-cars";

        public ExampleControllerIntegrationTests(ServerFixture server)
        {
            _server = server;
            _server.CleanDatabase();
        }

        [Fact]
        public async Task GetExample_ShouldReturnOk()
        {
            //Arrange
            var expectedName = "Sprinter XYZ";
            long expectedId = AddExampleToDb(expectedName);

            //Act
            var server = _server.HttpServer.TestServer;
            var client = server?.CreateClient();
            var response = await client.GetAsync(GetExampleUri(expectedId.ToString()));

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var exampleResponse = await response.Content.ReadAsAsync<ExampleResponse>();
            Assert.Equal(expectedId, exampleResponse.Id);
            Assert.Equal(expectedName, exampleResponse.Name);
        }

        private long AddExampleToDb(string name)
        {
            return (long)_server.HttpServer.Session.Save(new ExampleEntity { Name = name });
        }

        private string GetExampleUri(string id)
        {
            return $"{BaseAddress}/{id}";
        }
    }
}