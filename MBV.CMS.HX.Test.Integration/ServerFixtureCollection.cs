using MBV.CMS.HX.Test.Infrastructure;
using Xunit;

namespace MBV.CMS.HX.Test.Integration
{
    [CollectionDefinition(Name)]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
        public const string Name = "ServerFixture collection";
    }
}
