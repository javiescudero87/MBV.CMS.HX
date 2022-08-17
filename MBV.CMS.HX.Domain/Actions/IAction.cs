using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public interface IAction
    {
        IElement Subject { get; }
        object Data { get; set; }
        object Evidence { get; set; }

        ActionStatusValues Status { get; }
    }
}
