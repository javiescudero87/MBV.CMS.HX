using MBV.CMS.HX.Domain;

namespace MBV.CMS.HX.Service.Interface
{
    public interface IToolActionService
    {
        Task<T> CreateToolActionAsync<T>(T toolAction) where T : ToolAction;

        Task ExecuteAsync<T>(T toolAction) where T : ToolAction;

        Task VerifyAsync(long id, string evidence);
    }
}