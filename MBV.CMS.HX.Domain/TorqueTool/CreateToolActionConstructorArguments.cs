using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class CreateToolActionConstructorArguments
    {
        public string Brand { get; protected set; }

        public CreateToolActionConstructorArguments(string brand)
        {
            Brand = brand;  
        }
    }
}
