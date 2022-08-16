using MBV.CMS.HX.DataAccess.Interface;
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
        public async void GetMBCar_ShouldBeSuccessful()
        {
            //Arrange
            var expectedId = 1;
            var expectedName = "Sprinter Test";

            _mBCarRepositoryMock.Setup(r => r.FindAsync(It.IsAny<long>()))
                .ReturnsAsync(new Domain.MBCar() { Id = expectedId, Name = expectedName });

            //Act

            var retrievedCar = await CreateSut().GetMBCarAsync(1);


            //Assert
            Assert.Equal(expectedId, retrievedCar.Id);
            Assert.Equal(expectedName, retrievedCar.Name);
        }
    }
}