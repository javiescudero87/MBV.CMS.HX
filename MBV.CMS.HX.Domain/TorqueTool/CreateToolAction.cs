using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class CreateToolAction : ManualVerificationAction<TorqueTool,CreateToolActionExecuteArguments, string>
    {
        public CreateToolAction(string brand) : base(null)
        {
            Brand = brand;
        }

        public string Brand { get; protected set; }

        public override string Sumary => $"Create and register in catalog a Torque tool branded {Brand}";

        public override IEnumerable<object> InternalExecute(CreateToolActionExecuteArguments data)
        {
            Subject = new TorqueTool(data.ToolId, Brand, data.Location, null);
            return new object[] { };
        }

        public override void ValidateEvidence(string evidence)
        {
        }
    }
}
