using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public class AutomaticActionExecuteResult<A, E>
    {
        public A ExecuteArguments { get; set; }
        public object[] Changes { get; set; }
        public E Evidence { get; set; }

        public AutomaticActionExecuteResult(A executeArguments, object[] changes, E evidence)
        {
            ExecuteArguments = executeArguments;
            Changes = changes;
            Evidence = evidence;
        }
    }
}
