using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class AutomaticVerificationAction<S, A, E> : Action<S, A, E> where S : IElement
    {
        protected AutomaticVerificationAction(S? subject) : base(subject) { }
        public abstract AutomaticActionExecuteResult<A, E> InternalExecute(A arguments);
        public override bool HasAutomaticVerification { get { return true; } }

        public override void Execute(object arguments)
        {
            var result = InternalExecute((A)arguments);
            foreach (var c in result.Changes)
                Subject.UpdateState(c);
            ExecuteArguments = result.ExecuteArguments;
            Evidence = result.Evidence;
            Status = ActionStatusValues.Executed;
        }

        public override void Verify(object evidence)
        {
            throw new InvalidOperationException();
        }
    }
}
