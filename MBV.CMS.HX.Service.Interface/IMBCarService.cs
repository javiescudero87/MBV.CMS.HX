
using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.Service.Interface
{
    public interface IMBCarService
    {
        Task<MBCar?> GetMBCarAsync(long id);
        Task<MBCar> CreateMBCarAsync(MBCar domainMBCar);
    }
}