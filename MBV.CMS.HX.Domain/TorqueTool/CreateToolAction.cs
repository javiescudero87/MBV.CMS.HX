using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class CreateToolAction : ManualVerificationAction<TorqueTool, CreateToolActionConstructorArguments,CreateToolActionExecuteArguments, string>
    {
        public CreateToolAction(CreateToolActionConstructorArguments args) : base(null, args)
        { }

        public override string Sumary => $"Create and register in catalog a Torque tool branded {TypeConstructorArguments.Brand}";

        public override IEnumerable<object> InternalExecute(CreateToolActionExecuteArguments data)
        {
            Subject = new TorqueTool(data.ToolId, TypeConstructorArguments.Brand, data.Location, null);
            return new object[] { };
        }

        public override void ValidateEvidence(string evidence)
        {
        }
    }
}
