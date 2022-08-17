using System.ComponentModel;

namespace MBV.CMS.HX.Domain
{
    public enum ActionStatusEnums
    {

        [Description("Planificada")]
        Planificada = 1,
        [Description("Ejecutada")]
        Ejecutada = 2,
        [Description("Realizada")]
        Realizada = 3
    }
}
