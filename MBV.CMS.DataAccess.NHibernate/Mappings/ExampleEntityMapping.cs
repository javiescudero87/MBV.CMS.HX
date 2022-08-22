using FluentNHibernate.Mapping;
using MBV.CMS.Domain;

namespace MBV.CMS.DataAccess.NHibernate.Mappings
{
    public class ExampleEntityMapping : ClassMap<ExampleEntity>
    {
        public ExampleEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
        }
    }
}