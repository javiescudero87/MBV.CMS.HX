using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public interface ISemiautomaticAction : IAction
    {
        void Execute(object data);
        void Verify();
    }
}
