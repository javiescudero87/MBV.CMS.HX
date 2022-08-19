using MBV.CMS.HX.Service.Interface;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.Service
{
    public class ToolActionService : IToolActionService
    {
        IToolActionRepository _toolActionRepository;
        public ToolActionService(IToolActionRepository toolActionRepository)
        {
            _toolActionRepository = toolActionRepository;
        }

        public async Task<T> CreateToolActionAsync<T>(T toolAction) where T : ToolAction
        {
            toolAction.Status = ActionStatusEnums.Planificada;
            var domainActionToolAdded =  await _toolActionRepository.SaveAsync(toolAction);
            return (T)domainActionToolAdded;
        }

        public async Task ExecuteAsync<T>(T toolAction) where T : ToolAction
        {
            var action = await _toolActionRepository.FindAsync(toolAction.Id);
            action.Execute(toolAction);
            await _toolActionRepository.SaveAsync(action);

        }

        public async Task VerifyAsync(long id, string evidence)
        {
            var action = await _toolActionRepository.FindAsync(id);
            action.Evidence = evidence;
            action.Status = ActionStatusEnums.Realizada;
            await _toolActionRepository.SaveAsync(action);
        }
    }
}
