using AutoMapper;
using MBV.CMS.HX.Api.ViewModels;

namespace MBV.CMS.HX.Api.Automapper
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
            //Your maps
            CreateMap<Domain.MBCar, MBCarResponse>();
            CreateMap<MBCarCreateRequest, Domain.MBCar>();


            CreateMap<ActionCreateRequest, Domain.CreateToolAction>();
            CreateMap<Domain.CreateToolAction, ActionResponse>();
        }
    }
}
