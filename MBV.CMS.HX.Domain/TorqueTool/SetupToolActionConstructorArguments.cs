using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class SetupToolActionConstructorArguments
    {
        public string Configuration { get; protected set; }

        public SetupToolActionConstructorArguments(string configuration)
        {
            Configuration = configuration;  
        }
    }
}
