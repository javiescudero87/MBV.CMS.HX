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
            get
            {
                if (_instance == null)
                    _instance = new Catalog(
                                    new ActionCatalogEntry("Crear Herramienta de Torque", typeof(CreateToolAction)),
                                    new ActionCatalogEntry("Configurar Herramienta de Torque Bosch", typeof(AutomaticSetupToolAction)),
                                    new ActionCatalogEntry("Configurar Herramienta de Torque Atlas Copco", typeof(ManualSetupToolAction))
                                    );
                return _instance;
            }
        }

        public List<ActionCatalogEntry> RegisteredActions { get; protected set; }

        public Catalog(params ActionCatalogEntry[] actions)
        {
            RegisteredActions = new List<ActionCatalogEntry>(actions);
        }

        public void RegisterActions(ActionCatalogEntry actionCatalogEntry)
        {
            RegisteredActions.Add(actionCatalogEntry);
        }
    }
}
