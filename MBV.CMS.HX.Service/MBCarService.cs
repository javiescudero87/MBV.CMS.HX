using MBV.CMS.HX.Common.Exceptions;
using MBV.CMS.HX.Common.LogsEvents;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;
using MBV.CMS.HX.Service.Interface;

namespace MBV.CMS.HX.Service
{
    public class MBCarService : IMBCarService
    {
        const string InvalidCarName = "forbidden car name";
        private readonly IMBCarRepository _mBCarRepository;
        public MBCarService(IMBCarRepository mBCarRepository)
        {
            _mBCarRepository = mBCarRepository;
        }

        public async Task<MBCar> CreateMBCarAsync(MBCar domainMBCar)
        {
            if (domainMBCar.Name.ToLower().Equals(InvalidCarName))
                throw new BusinessException(ServiceEvents.ExceptionInCreateMBCarAsync,
                    new Error
                    {
                        Code = "ER10",
                        Title = "Validation error",
                        Detail = $"Invalid name: {domainMBCar.Name}"
                    });

            return await _mBCarRepository.SaveAsync(domainMBCar);
        }

        public async Task<MBCar?> GetMBCarAsync(long id)
        {
            return await _mBCarRepository.FindAsync(id);
        }
    }
}