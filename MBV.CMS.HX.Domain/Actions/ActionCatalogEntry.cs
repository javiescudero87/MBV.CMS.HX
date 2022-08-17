using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public class ActionCatalogEntry
    {
        public string Name { get; set; }
        public Type Action { get; set; }
        public Type ExecuteArguments { get; set; }
        public Type Evidence { get; set; }

        public ActionCatalogEntry(string name, Type action, Type executeArguments, Type evidence)
        {
            Name = name;
            Action = action;
            ExecuteArguments = executeArguments;
            Evidence = evidence;
        }
    }
}
