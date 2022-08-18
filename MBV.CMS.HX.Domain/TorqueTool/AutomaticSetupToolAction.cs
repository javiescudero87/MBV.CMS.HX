using MBV.CMS.HX.Domain.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class AutomaticSetupToolAction : AutomaticVerificationAction<TorqueTool, SetupToolActionConstructorArguments, VoidType, string>
    {
        public virtual ITorqueToolApi API { get; protected set; }

        public override string Sumary => $"Setup Torque Tool {Subject} with new Configuration";

        public AutomaticSetupToolAction(TorqueTool subject, SetupToolActionConstructorArguments args, ITorqueToolApi api) : base(subject, args)
        {
            API = api;
        }

        public override AutomaticActionExecuteResult<VoidType, string> InternalExecute(VoidType arguments)
        {
            //Aca llamo la api con la configuración, algo asi como:
            API.SetToolConfiguration(TypedSubject.ToolId, TypeConstructorArguments.Configuration);
            var state = API.GetToolConfiguration(TypedSubject.ToolId);
            if (state != TypeConstructorArguments.Configuration) 
                throw new Exception();

            return new AutomaticActionExecuteResult<VoidType, string>(
                new VoidType(),
                new[] { new TorqueToolUpdateConfiguration(TypeConstructorArguments.Configuration) },
                state
                );
        }
    }
}
