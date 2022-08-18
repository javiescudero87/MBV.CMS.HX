using MBV.CMS.HX.Common.Exceptions;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;
using MBV.CMS.HX.Domain.Catalog;
using MBV.CMS.HX.Domain.TorqueTool;
using MBV.CMS.HX.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MBV.CMS.HX.Test.Unit.Domain.Actions
{
    public class CatalogTests
    {
        public CatalogTests()
        { }
            

        private Catalog CreateSut()
        {
            return new Catalog();
        }

        [Fact]
        public async void RegisteredActions_MustHaveValues()
        {
            //Arrange
            var expectedName = "name";
            var expectedActionType = typeof(CreateToolAction);
            var catalog = CreateSut();
            
            //Act
            catalog.RegisterActions(new ActionCatalogEntry(expectedName,expectedActionType));

            //Assert
            Assert.NotNull(catalog.RegisteredActions);
            Assert.True(catalog.RegisteredActions.Count == 1);
            Assert.Equal(expectedName, catalog.RegisteredActions[0].Name);
            Assert.Equal(expectedActionType, catalog.RegisteredActions[0].Action);
        }


    }
}
