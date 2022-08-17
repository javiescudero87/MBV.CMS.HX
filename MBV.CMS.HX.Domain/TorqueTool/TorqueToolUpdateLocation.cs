using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class TorqueToolUpdateLocation
    {
        public string Location { get; protected set; }
        public TorqueToolUpdateLocation(string location)
        {
            Location = location;
        }
    }
}
