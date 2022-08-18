using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class Action<S, A, E> : IAction where S : IElement
    {
        #region IAction Properties

        public virtual IElement? Subject { get; protected set; }

        public virtual object? ExecuteArguments { get; set; }

        public virtual object? Evidence { get; set; }
        public virtual ActionStatusValues Status { get; protected set; }

        public virtual Type ExecuteArgumentsType => typeof(A);
        public virtual Type EvidenceType => typeof(E);

        #endregion

        #region Typed Properties
        public virtual S? TypedSubject => (S?)Subject; 
        public virtual A? TypedExecuteArguments => (A?)ExecuteArguments; 
        public virtual E? TypedEvidence => (E?)Evidence;

        public abstract string Sumary { get; }
        #endregion

        public abstract void Execute(object arguments);
        public abstract void Verify(object evidence);
        public abstract bool HasAutomaticVerification { get; }

        public Action(S? subject)
        {
            Subject = subject;
            Status = ActionStatusValues.Pending;
            ExecuteArguments = null;
            Evidence = null;
        }
    }
}
