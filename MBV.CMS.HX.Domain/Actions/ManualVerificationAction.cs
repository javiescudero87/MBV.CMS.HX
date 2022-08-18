using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class ManualVerificationAction<S, A, E> : Action<S, A, E> where S: IElement
    {
        protected ManualVerificationAction(S? subject) 
            : base(subject) { }

        public abstract IEnumerable<object> InternalExecute(A arguments);
        public abstract void ValidateEvidence(E evidence);

        public override bool HasAutomaticVerification { get { return false; } }

        public override void Execute(object arguments)
        {
            ExecuteArguments = arguments;
            var changes = InternalExecute((A)arguments);
            foreach (var c in changes)
                Subject.UpdateState(c);
            Status = ActionStatusValues.Executed;
        }

        public override void Verify(object evidence)
        {
            ValidateEvidence((E)evidence);
            Evidence = evidence;
            Status = ActionStatusValues.Done;
        }

    }
}
