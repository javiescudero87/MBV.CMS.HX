using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public interface IAction
    {
        IElement Subject { get; }
        string Sumary { get; }
        object ExecuteArguments { get; set; }
        object Evidence { get; set; }
        ActionStatusValues Status { get; }

        Type ExecuteArgumentsType {get;}
        Type EvidenceType { get; }

        bool HasAutomaticVerification { get; }
        void Execute(object arguments);
        void Verify(object evidence);
    }
}
