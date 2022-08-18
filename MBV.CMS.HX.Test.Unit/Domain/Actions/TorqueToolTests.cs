using MBV.CMS.HX.Domain.Actions;
using MBV.CMS.HX.Domain.TorqueTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MBV.CMS.HX.Test.Unit.Domain.Actions
{
    public class TorqueToolTests
    {
        public TorqueToolTests()
        {

        }

        [Fact]
        public void CreateTorqueTool_Create_ShouldCreateAndAction()
        {
            //Arrange
            var expectedBrand = "Bosch";

            //Act
            var action = new CreateToolAction(new CreateToolActionConstructorArguments(expectedBrand));

            //Assert
            Assert.Equal(expectedBrand, action.TypeConstructorArguments.Brand);
            Assert.Null(action.Subject);
            Assert.Null(action.ExecuteArguments);
            Assert.Null(action.Evidence);
            Assert.Equal(ActionStatusValues.Pending, action.Status);
        }

        [Fact]
        public void CreateTorqueTool_Execute_ShouldChangeToolAndStatus()
        {
            //Arrange
            var brand = "Bosch";
            var expectedToolId = "0001";
            var expectedLocation = "Available Tools Inventory";
            var action = new CreateToolAction(new CreateToolActionConstructorArguments(brand));

            //Act
            action.Execute(new CreateToolActionExecuteArguments(expectedToolId, expectedLocation));

            //Assert
            Assert.Equal(brand, action.TypeConstructorArguments.Brand);
            Assert.IsType<TorqueTool>(action.Subject);
            Assert.Equal(expectedToolId, action.TypedExecuteArguments.ToolId);
            Assert.Equal(expectedLocation, action.TypedExecuteArguments.Location);
            Assert.Null(action.Evidence);
            Assert.Equal(ActionStatusValues.Executed, action.Status);

            Assert.Equal(brand, action.TypedSubject.Brand);
            Assert.Equal(expectedToolId, action.TypedSubject.ToolId);
            Assert.Equal(expectedLocation, action.TypedSubject.Location);
            Assert.Null(action.TypedSubject.Configuration);
        }
    }
}
