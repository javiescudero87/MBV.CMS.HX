using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class SemiautomaticAction<T, D, E> : Action<T>, ISemiautomaticAction where T: IElement
    {
        protected SemiautomaticAction(T? subject) : base(subject)
        {
        }

        public abstract object[] InternalExecute(D data);
        protected abstract object? InternalVerify();

        public void Execute(object data)
        {
            var Data = data;
            var changes = InternalExecute((D)data);

            foreach (var c in changes)
                Subject.UpdateState(c);

            Status = ActionStatusValues.Executed;
        }

        public void Verify()
        {
            Evidence = InternalVerify();
            Status = ActionStatusValues.Done;
        }

    }
}
