using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public class AutomaticActionExecuteResult<D, E>
    {
        public D Data { get; set; }
        public object[] Changes { get; set; }
        public E Evidence { get; set; }

        public AutomaticActionExecuteResult(D data, object[] changes, E evidence)
        {
            Data = data;
            Changes = changes;
            Evidence = evidence;
        }
    }
}
