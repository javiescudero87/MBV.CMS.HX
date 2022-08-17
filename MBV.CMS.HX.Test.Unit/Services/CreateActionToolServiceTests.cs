using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Service;
using Moq;
using Xunit;

namespace MBV.CMS.HX.Test.Unit.Services
{
    public class CreateActionToolServiceTests
    {
        private readonly Mock<ICreateActionToolRepository> _createToolActionRepositoryMock;

        public CreateActionToolServiceTests()
        {
            _createToolActionRepositoryMock = new Mock<ICreateActionToolRepository>();
        }

        private CreateActionToolService CreateSut()
        {
            return new CreateActionToolService(_createToolActionRepositoryMock.Object);
        }

        [Fact]
        public async void CreateCreateToolAction_ShouldBeSuccessful()
        {
            //Arrange
            var expectedBrand = "Bosch";
            var expectedDescription = "Torque";


            var expectedActionAdded = new Domain.CreateToolAction
            {
                Id = 1,
                Brand = expectedBrand,
                Description = expectedDescription
            };

            _createToolActionRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<Domain.CreateToolAction>()))
                .ReturnsAsync(expectedActionAdded);

            //Act

            var retrievedToolAction = await CreateSut().CreateCreateToolActionAsync(
                new Domain.CreateToolAction
                {
                    Brand = expectedBrand,
                    Description = expectedDescription
                }
                );


            //Assert
            Assert.True(retrievedToolAction.Id > 0);
            Assert.Equal(expectedBrand, retrievedToolAction.Brand);
            Assert.Equal(expectedDescription, retrievedToolAction.Description);

        }
    }
}
