using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class AutomaticSetupToolAction : AutomaticVerificationAction<TorqueTool, VoidType, string>
    {
        public virtual string Configuration { get; set; }

        public override string Sumary => $"Setup Torque Tool {Subject} with new Configuration";

        public AutomaticSetupToolAction(TorqueTool subject,string configuration) : base(subject)
        {
            Configuration = configuration;
        }

        public override AutomaticActionExecuteResult<VoidType, string> InternalExecute(VoidType arguments)
        {
            //Aca llamo la api con la configuración, algo asi como:
            //  API.SetConifguration(Subject.ToolId, Configuration);
            //  var state = API.GetConfiguration(Subject.ToolId);
            //  if (state != Configuration) throw new Exception();
            //  Evidence = state;

            var evidence = "API RESULT";
            return new AutomaticActionExecuteResult<VoidType, string>(
                new VoidType(),
                new[] { new TorqueToolUpdateConfiguration(Configuration) },
                evidence
                );
        }
    }
}
