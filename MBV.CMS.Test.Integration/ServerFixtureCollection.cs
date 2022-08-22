using MBV.CMS.Test.Infrastructure;
using Xunit;

namespace MBV.CMS.Test.Integration
{
    [CollectionDefinition(Name)]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
        public const string Name = "ServerFixture collection";
    }
}
