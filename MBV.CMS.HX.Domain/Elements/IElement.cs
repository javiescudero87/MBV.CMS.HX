using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Elements
{
    public interface IElement
    {
        void UpdateState(object stateChange);
    }
}
