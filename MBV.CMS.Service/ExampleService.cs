using MBV.CMS.DataAccess.Interface;
using MBV.CMS.Domain;
using MBV.CMS.Lainco.Exceptions;
using MBV.CMS.Service.Interface;

namespace MBV.CMS.Service
{
    public class ExampleService : IExampleService
    {
        const string InvalidExampleName = "forbidden car name";
        private readonly IExampleRepository _exampleRepository;
        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<ExampleEntity> CreateExampleAsync(ExampleEntity domainExample)
        {
            if (domainExample.Name.ToLower().Equals(InvalidExampleName))
                throw new BusinessException(
                    new Error
                    {
                        Code = "ER10",
                        Title = "Validation error",
                        Detail = $"Invalid name: {domainExample.Name}"
                    });

            return await _exampleRepository.SaveAsync(domainExample);
        }

        public async Task<ExampleEntity?> GetExampleAsync(long id)
        {
            return await _exampleRepository.FindAsync(id);
        }
    }
}