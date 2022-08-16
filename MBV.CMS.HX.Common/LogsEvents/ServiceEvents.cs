using Microsoft.Extensions.Logging;

namespace Sa.Demo.Common.LogsEvents
{
    public class ServiceEvents
    {
        public static EventId EnteringToGetMBCar { get; } = new EventId(1000, "Calling method GetMBCar() en MBV.CMC.HX.Services.MBCarService");
        public static EventId ExceptionInGetMBCar { get; } = new EventId(1001, "Exception ocurrs calling method GetMBCar() en MBV.CMC.HX.Services.MBCarService");
    }
}
