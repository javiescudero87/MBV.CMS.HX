using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class CreateToolActionExecuteArguments
    {
        public string ToolId { get; set; }
        public string Location { get; set; }

        public CreateToolActionExecuteArguments(string toolId, string location)
        {
            ToolId = toolId;
            Location = location;
        }   
    }
}
