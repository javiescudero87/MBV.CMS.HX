using MBV.CMS.Domain;

namespace MBV.CMS.Service.Interface
{
    public interface IExampleService
    {
        Task<ExampleEntity?> GetExampleAsync(long id);
        Task<ExampleEntity> CreateExampleAsync(ExampleEntity domainExample);
    }
}