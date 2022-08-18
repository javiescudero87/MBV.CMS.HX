using MBV.CMS.HX.Domain.TorqueTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Catalog
{
    public class Catalog
    {
        private static Catalog? _instance = null;
        public static Catalog Instance
        {
            get { if (_instance == null) _instance = new Catalog(); return _instance; }
        }

        public List<ActionCatalogEntry> RegisterdActions { get; protected set; }

        public Catalog()
        {
            RegisterdActions = new List<ActionCatalogEntry>()
            {
                new ActionCatalogEntry("Crear Herramienta de Torque", typeof(CreateToolAction)),
                new ActionCatalogEntry("Configurar Herramienta de Torque Bosch", typeof(AutomaticSetupToolAction)),
                new ActionCatalogEntry("Configurar Herramienta de Torque Atlas Copco", typeof(ManualSetupToolAction)),
            };
        }

    }
}
