using AutoMapper;
using MBV.CMS.Api.ViewModels;
using MBV.CMS.Lainco.Extensions;
using MBV.CMS.Domain;

namespace MBV.CMS.Api.Automapper
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainViewModelMappingProfile()
        {
            //Request            
            CreateMap<ExampleCreateRequest, ExampleEntity>();

            //Response
            CreateMap<ExampleEntity, ExampleResponse>();
        }
    }
}
