using MBV.CMS.HX.Domain.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.TorqueTool
{
    public class TorqueTool : IElement
    {
        public string ToolId { get; set; }
        public string Brand { get; set; }
        public string? Location { get; set; }
        public string? Configuration { get; set; }

        public TorqueTool(string toolId, string brand, string? location, string? configuration)
        {
            ToolId = toolId;
            Brand = brand;
            Location = location;
            Configuration = configuration;
        }

        public void UpdateState(object stateChange)
        {
            UpdateState((dynamic)stateChange);   
        }

        public void UpdateState(TorqueToolUpdateLocation change)
        {
            Location = change.Location;
        }

        public void UpdateState(TorqueToolUpdateConfiguration change)
        {
            Configuration = change.Configuration;
        }
    }
}
