using MBV.CMS.HX.Common.Exceptions;
using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class ManualAction<T, D, E> : Action<T>, IManualAction where T: IElement
    {
        public abstract IEnumerable<object> InternalExecute(D data);
        public virtual void ValidateEvidence(E evidence)
        {
            if (evidence == null) throw new BusinessException(new Microsoft.Extensions.Logging.EventId(0, ""), new Error() { Title = "Must provide evidence of the verifaction" }, System.Net.HttpStatusCode.PreconditionFailed);
        }

        public ManualAction(T? subject) : base(subject) { }

        public void Execute(object data)
        {
            var Data = data;
            var changes = InternalExecute((D)data);
            
            foreach (var c in changes)
                Subject.UpdateState(c);

            Status = ActionStatusValues.Executed;
        }

        public void Verify(object evidence)
        {
            Evidence = evidence;
            ValidateEvidence((E)evidence);
            Status = ActionStatusValues.Done;
        }
    }
}
