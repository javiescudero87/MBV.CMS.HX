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

        private CreateActionToolService ExecuteSut()
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

        [Fact]
        public async void ExecuteToolAction_ShouldBeSuccessful()
        {
            // ARRANGE
            var id = 1;
            var toolId = "TQ001";            
            var location = "Depósito de Herramientas";
            var expectedBrand = "Bosch";
            var expectedDescription = "Torque";
            var expectedActionAdded = new Domain.CreateToolAction
            {
                Id = 1,
                Brand = expectedBrand,
                Description = expectedDescription
            };

            //ACT
            _createToolActionRepositoryMock.Setup(r => r.FindAsync(It.IsAny<long>())).ReturnsAsync(expectedActionAdded);
            _createToolActionRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<Domain.CreateToolAction>()));
            await ExecuteSut().ExecuteAsync(id, toolId, location);

            //ASSERT
            _createToolActionRepositoryMock.Verify(v => v.FindAsync(id));
            _createToolActionRepositoryMock.Verify(v => v.SaveAsync(It.IsAny<Domain.CreateToolAction>()));
        }
    }
}
