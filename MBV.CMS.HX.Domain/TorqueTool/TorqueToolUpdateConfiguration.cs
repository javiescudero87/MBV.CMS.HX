using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class TorqueToolUpdateConfiguration
    {
        public string Configuration { get; protected set; }
        public TorqueToolUpdateConfiguration(string configuration)
        {
            Configuration = configuration;
        }
    }
}
