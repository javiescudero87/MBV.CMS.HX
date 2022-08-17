using MBV.CMS.HX.Domain.TorqueTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Actions
{
    public class ActionsCatalog
    {
        private static ActionsCatalog _instance = null;
        public static ActionsCatalog Instance
        {
            get { if (_instance == null) _instance = new ActionsCatalog(); return _instance; }
        }

        public List<ActionCatalogEntry> RegisterdActions { get; protected set; }

        public ActionsCatalog()
        {
            RegisterdActions = new List<ActionCatalogEntry>()
            {
                new ActionCatalogEntry("Crear Herramienta de Torque", typeof(CreateToolAction), typeof(CreateToolActionExecuteArguments), typeof(string)),
                new ActionCatalogEntry("Configurar Herramienta de Torque Bosch", typeof(AutomaticSetupToolAction), typeof(int), typeof(string)),
                new ActionCatalogEntry("Configurar Herramienta de Torque Atlas Copco", typeof(ManualSetupToolAction), typeof(int), typeof(string)),
            };
        }

    }
}
