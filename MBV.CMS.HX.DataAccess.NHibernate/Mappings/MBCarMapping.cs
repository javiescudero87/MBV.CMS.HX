using FluentNHibernate.Mapping;
using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.DataAccess.NHibernate.Mappings
{
    public class MBCarMapping : ClassMap<MBCar>
    {
        public MBCarMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
        }
    }
}