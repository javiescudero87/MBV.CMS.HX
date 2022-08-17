using MBV.CMS.HX.Service.Interface;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.Service
{
    public class CreateActionToolService : ICreateActionToolService
    {
        ICreateActionToolRepository _createActionToolRepository;
        public CreateActionToolService(ICreateActionToolRepository createActionToolRepository)
        {
            _createActionToolRepository = createActionToolRepository;
        }

        public async Task<CreateToolAction> CreateCreateToolActionAsync(CreateToolAction domainCreateActionTool)
        {
            var domainCreateActionToolAdded =  await _createActionToolRepository.SaveAsync(domainCreateActionTool);
            return domainCreateActionToolAdded;
        }
    }
}
