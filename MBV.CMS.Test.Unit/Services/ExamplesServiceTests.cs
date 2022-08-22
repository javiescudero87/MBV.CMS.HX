using MBV.CMS.Lainco.Exceptions;
using MBV.CMS.DataAccess.Interface;
using MBV.CMS.Domain;
using MBV.CMS.Service;
using Moq;
using Xunit;

namespace MBV.CMS.Test.Unit.Services
{
    public class ExamplesServiceTests
    {
        private readonly Mock<IExampleRepository> _exampleRepositoryMock;

        public ExamplesServiceTests()
        {
            _exampleRepositoryMock = new Mock<IExampleRepository>();
        }

        private ExampleService CreateSut()
        {
            return new ExampleService(_exampleRepositoryMock.Object);
        }

        [Fact]
        public async void CreateExample_WhenRequesterDoesNotExist_ShouldFail()
        {
            //Arrange
            var name = "Forbidden car name";
            var carToAdd = new ExampleEntity { Name = name };

            //Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => CreateSut().CreateExampleAsync(carToAdd));

            //Assert
            Assert.Contains($"Invalid name: {name}", ex.Errors[0].Detail);
        }

        [Fact]
        public async void GetExample_ShouldBeSuccessful()
        {
            //Arrange
            var expectedId = 1;
            var expectedName = "Sprinter Test";

            _exampleRepositoryMock.Setup(r => r.FindAsync(It.IsAny<long>()))
                .ReturnsAsync(new ExampleEntity() { Id = expectedId, Name = expectedName });

            //Act

            var retrievedExample = await CreateSut().GetExampleAsync(1);


            //Assert
            Assert.Equal(expectedId, retrievedExample.Id);
            Assert.Equal(expectedName, retrievedExample.Name);
        }
    }
}