namespace MBV.CMS.HX.Domain
{
    public abstract class ToolAction
    {
        public virtual long Id { get; set; }
        public virtual string Evidence { get; set; }
        public virtual string Description { get; set; }
        public virtual ActionStatusEnums Status { get; set; }






        public abstract void Execute(ToolAction toolActionData);
        public abstract void Verify(ToolAction toolActionData);

    }
}