namespace MBV.CMS.HX.Domain
{
    public class CreateToolAction
    {
        public virtual long Id { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Description { get; set; }
        public virtual string ToolId { get; set; }
        public virtual string Location { get; set; }
        public virtual ActionStatusEnums Status { get; set; }
        public string Evidence { get; set; }
    }
}