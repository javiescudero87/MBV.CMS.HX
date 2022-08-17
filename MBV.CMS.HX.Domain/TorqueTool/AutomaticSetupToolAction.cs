using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class AutomaticSetupToolAction : AutomaticAction<TorqueTool, int, string>
    {
        public string Configuration { get; set; }

        public AutomaticSetupToolAction(TorqueTool subject,string configuration) : base(subject)
        {
            Configuration = configuration;
        }

        public override AutomaticActionExecuteResult<int, string> InternalExecute()
        {
            //Aca llamo la api con la configuración, algo asi como:
            //  API.SetConifguration(Subject.ToolId, Configuration);
            //  var state = API.GetConfiguration(Subject.ToolId);
            //  if (state != Configuration) throw new Exception();
            //  Evidence = state;

            var evidence = "API RESULT";
            return new AutomaticActionExecuteResult<int, string>(
                0,
                new[] { new TorqueToolUpdateConfiguration(Configuration) },
                evidence
                );
        }
    }
}
