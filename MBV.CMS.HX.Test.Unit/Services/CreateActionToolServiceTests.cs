﻿using MBV.CMS.HX.DataAccess.Interface;
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

        [Fact]
        public async void ExecuteToolAction_ShouldBeSuccessful()
        {
            // ARRANGE
            var id = 1;
            var brand = "Bosch";
            var description = "Torque";
            var expectedToolId = "TQ001";
            var expetedLocation = "Depósito de Herramientas";
            var expectedActionAdded = new Domain.CreateToolAction
            {
                Id = 1,
                Brand = brand,
                Description = description
            };

            //ACT
            _createToolActionRepositoryMock.Setup(r => r.FindAsync(id)).ReturnsAsync(expectedActionAdded);
            _createToolActionRepositoryMock.Setup(r => r.SaveAsync(expectedActionAdded));
            await CreateSut().ExecuteAsync(id, expectedToolId, expetedLocation);

            //ASSERT
            _createToolActionRepositoryMock.Verify(v => v.FindAsync(id));
            _createToolActionRepositoryMock.Verify(v => v.SaveAsync(It.IsAny<Domain.CreateToolAction>()));
        }

        [Fact]
        public async void VerifyToolAction_ShouldBeSuccessful()
        {
            // ARRANGE
            var id = 1;
            var toolId = "TQ001";
            var location = "Depósito de Herramientas";
            var brand = "Bosch";
            var description = "Torque";
            var expectedEvidence = "evidence";
            var expectedActionAdded = new Domain.CreateToolAction
            {
                Id = 1,
                Brand = brand,
                Description = description,
                ToolId = toolId,
                Location = location
            };

            //ACT
            _createToolActionRepositoryMock.Setup(r => r.FindAsync(id)).ReturnsAsync(expectedActionAdded);
            _createToolActionRepositoryMock.Setup(r => r.SaveAsync(expectedActionAdded));
            await CreateSut().VerifyAsync(id, expectedEvidence);

            //ASSERT
            _createToolActionRepositoryMock.Verify(v => v.FindAsync(id));
            _createToolActionRepositoryMock.Verify(v => v.SaveAsync(It.IsAny<Domain.CreateToolAction>()));
        }

    }
}
