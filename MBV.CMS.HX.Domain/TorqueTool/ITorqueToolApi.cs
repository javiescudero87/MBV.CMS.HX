using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public interface ITorqueToolApi
    {
        void SetToolConfiguration(string id, string configuration);
        string GetToolConfiguration(string id);
    }
}
