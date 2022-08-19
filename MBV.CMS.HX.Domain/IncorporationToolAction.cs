namespace MBV.CMS.HX.Domain
{
    public class IncorporationToolAction : ToolAction
    {
        public virtual string Brand { get; set; }
        public virtual string ToolId { get; set; }
        public virtual string Location { get; set; }


        public override void Execute(ToolAction toolActionData)
        {
            Location = ((IncorporationToolAction)toolActionData).Location;
            ToolId = ((IncorporationToolAction)toolActionData).ToolId;
            Status = ActionStatusEnums.Ejecutada;
        }

        public override void Verify(ToolAction toolActionData)
        {
            throw new NotImplementedException();
        }
    }
}