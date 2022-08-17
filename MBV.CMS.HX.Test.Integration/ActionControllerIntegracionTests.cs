using MBV.CMS.HX.Api.ViewModels;
using MBV.CMS.HX.Test.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MBV.CMS.HX.Test.Integration
{
    [Collection(ServerFixtureCollection.Name)]
    public class ActionControllerIntegracionTests
    {
        private readonly ServerFixture _server;
        private const string BaseAddress = "/api/v1/actions";

        public ActionControllerIntegracionTests(ServerFixture server)
        {
            _server = server;
            _server.CleanDatabase();
        }

        [Fact]
        public async Task CreateAction_ShouldReturnOk()
        {
            //Arrange
            var expectedBrand = "Bosch";
            var expectedDescription = "Herramienta de torque";

            var server = _server.HttpServer.TestServer;
            var client = server?.CreateClient();

            //Act
            dynamic request = new
            {
                brand = expectedBrand,
                description = expectedDescription
            };

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseAddress, httpContent);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var actionResponse = await response.Content.ReadAsAsync<ActionResponse>();
            Assert.True(actionResponse.Id > 0);
            Assert.Null(actionResponse.ToolId);
            Assert.Equal(expectedBrand, actionResponse.Brand);
            Assert.Equal(expectedDescription, actionResponse.Description);
        }
    }
}
