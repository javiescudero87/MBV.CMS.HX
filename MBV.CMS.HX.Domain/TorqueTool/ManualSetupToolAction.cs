using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class ManualSetupToolAction : ManualVerificationAction<TorqueTool, int, string>
    {
        public string Configuration { get; protected set; }
        public override string Sumary => $"Setup Torque Tool {Subject} with new Configuration";

        public ManualSetupToolAction(TorqueTool? subject, string configuration) : base(subject)
        {
            Configuration = configuration;
        }

        public override IEnumerable<object> InternalExecute(int data)
        {
            yield return new TorqueToolUpdateConfiguration(Configuration);
        }

        public override void ValidateEvidence(string evidence)
        {
            throw new NotImplementedException();
        }
    }
}
