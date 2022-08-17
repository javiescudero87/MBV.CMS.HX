using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.Service.Interface
{
    public interface ICreateActionToolService
    {
        Task<CreateToolAction> CreateCreateToolActionAsync(CreateToolAction domainMBCar);
    }
}