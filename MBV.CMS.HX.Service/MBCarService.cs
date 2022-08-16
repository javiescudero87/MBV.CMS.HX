using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;
using MBV.CMS.HX.Service.Interface;

namespace MBV.CMS.HX.Service
{
    public class MBCarService : IMBCarService
    {
        private readonly IMBCarRepository _mBCarRepository;
        public MBCarService(IMBCarRepository mBCarRepository)
        {
            _mBCarRepository = mBCarRepository;
        }

        public async Task<MBCar> CreateMBCarAsync(MBCar domainMBCar)
        {
            return await _mBCarRepository.SaveAsync(domainMBCar);
        }

        public async Task<MBCar?> GetMBCarAsync(long id)
        {
            return await _mBCarRepository.FindAsync(id);
        }
    }
}