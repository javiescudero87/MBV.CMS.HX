using MBV.CMS.HX.Common.Exceptions;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;
using MBV.CMS.HX.Service;
using Moq;
using Xunit;

namespace MBV.CMS.HX.Test.Unit.Services
{
    public class MBCarServiceTests
    {
        private readonly Mock<IMBCarRepository> _mBCarRepositoryMock;

        public MBCarServiceTests()
        {
            _mBCarRepositoryMock = new Mock<IMBCarRepository>();
        }

        private MBCarService CreateSut()
        {
            return new MBCarService(_mBCarRepositoryMock.Object);
        }

        [Fact]
        public async void CreateRequirement_WhenRequesterDoesNotExist_ShouldFail()
        {
            //Arrange
            var name = "Forbidden car name";
            var carToAdd = new MBCar { Name = name };

            //Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => CreateSut().CreateMBCarAsync(carToAdd));

            //Assert
            Assert.Contains($"Invalid name: {name}", ex.Errors[0].Detail);
        }

        [Fact]
        public async void GetMBCar_ShouldBeSuccessful()
        {
            //Arrange
            var expectedId = 1;
            var expectedName = "Sprinter Test";

            _mBCarRepositoryMock.Setup(r => r.FindAsync(It.IsAny<long>()))
                .ReturnsAsync(new MBCar() { Id = expectedId, Name = expectedName });

            //Act

            var retrievedCar = await CreateSut().GetMBCarAsync(1);


            //Assert
            Assert.Equal(expectedId, retrievedCar.Id);
            Assert.Equal(expectedName, retrievedCar.Name);
        }
    }
}