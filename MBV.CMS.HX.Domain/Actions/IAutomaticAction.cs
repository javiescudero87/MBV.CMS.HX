using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public interface IAutomaticAction : IAction
    {
        void Execute();
    }
}
