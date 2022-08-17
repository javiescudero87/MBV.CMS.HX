using Microsoft.Extensions.Logging;

namespace MBV.CMS.HX.Common.LogsEvents
{
    public class ServiceEvents
    {
        public static EventId EnteringToCreateMBCarAsync { get; } = new EventId(1000, "Calling method CreateMBCarAsync() in MBV.CMC.HX.Services.MBCarService");
        public static EventId ExceptionInCreateMBCarAsync { get; } = new EventId(1001, "Exception ocurrs calling method CreateMBCarAsync() in MBV.CMC.HX.Services.MBCarService");
    }
}
