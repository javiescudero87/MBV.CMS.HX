using FluentNHibernate.Mapping;
using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.DataAccess.NHibernate.Mappings
{
    public class CreateToolActionMapping : ClassMap<CreateToolAction>
    {
        public CreateToolActionMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Brand);
            Map(x => x.Description);
            Map(x => x.ToolId);
            Map(x => x.Location);
            Map(x => x.Evidence);
            Map(x => x.Status);
        }
    }
}