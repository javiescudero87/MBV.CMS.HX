using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Catalog
{
    public class ActionCatalogEntry
    {
        public string Name { get; set; }
        public Type Action { get; set; }

        public ActionCatalogEntry(string name, Type action)
        {
            Name = name;
            Action = action;
        }
    }
}
