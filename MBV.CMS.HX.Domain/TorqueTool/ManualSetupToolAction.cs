using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class ManualSetupToolAction : ManualVerificationAction<TorqueTool, SetupToolActionConstructorArguments, VoidType, string>
    {
        public string Configuration { get; protected set; }
        public override string Sumary => $"Setup Torque Tool {Subject} with new Configuration";

        public ManualSetupToolAction(TorqueTool? subject, SetupToolActionConstructorArguments args) : base(subject, args)
        {
        }

        public override IEnumerable<object> InternalExecute(VoidType data)
        {
            yield return new TorqueToolUpdateConfiguration(TypeConstructorArguments.Configuration);
        }

        public override void ValidateEvidence(string evidence)
        {
        }
    }
}
