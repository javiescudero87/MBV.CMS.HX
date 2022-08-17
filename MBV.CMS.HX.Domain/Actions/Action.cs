using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class Action<T> : IAction where T : IElement
    {
        #region Properties

        public IElement? Subject { get; protected set; }

        public object? Data { get; set; }

        public object? Evidence { get; set; }
        public ActionStatusValues Status { get; protected set; }

        #endregion

        public Action(T? subject)
        {
            Subject = subject;
            Status = ActionStatusValues.Pending;
            Data = null;
            Evidence = null;
        }
    }
}
