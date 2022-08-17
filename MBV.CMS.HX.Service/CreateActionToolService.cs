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

        public async Task ExecuteAsync(long id, string toolId, string location)
        {
            var action = await _createActionToolRepository.FindAsync(id);
            action.Location = location;
            action.ToolId = toolId;
            action.Status = ActionStatusEnums.Ejecutada;
            await _createActionToolRepository.SaveAsync(action);
        }
    }
}
