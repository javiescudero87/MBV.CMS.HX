using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Elements
{
    public abstract class Element
    {
        public abstract void UpdateState(string data);
    }
}
