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
        public virtual string Configuration { get; protected set; }
        public virtual ITorqueToolApi API { get; protected set; }

        public override string Sumary => $"Setup Torque Tool {Subject} with new Configuration";

        public AutomaticSetupToolAction(TorqueTool subject,string configuration, ITorqueToolApi api) : base(subject)
        {
            Configuration = configuration;
        }

        public override AutomaticActionExecuteResult<VoidType, string> InternalExecute(VoidType arguments)
        {
            //Aca llamo la api con la configuración, algo asi como:
            API.SetToolConfiguration(TypedSubject.ToolId, Configuration);
            var state = API.GetToolConfiguration(TypedSubject.ToolId);
            if (state != Configuration) 
                throw new Exception();

            return new AutomaticActionExecuteResult<VoidType, string>(
                new VoidType(),
                new[] { new TorqueToolUpdateConfiguration(Configuration) },
                state
                );
        }
    }
}
