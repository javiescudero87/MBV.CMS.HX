using AutoMapper;
using MBV.CMS.HX.Api.ViewModels;
using MBV.CMS.HX.Common.Extensions;
using MBV.CMS.HX.Domain;

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
            //Request            
            CreateMap<MBCarCreateRequest, MBCar>();
            CreateMap<IncorporationActionRequest, IncorporationToolAction>();
            CreateMap<ExecuteActionRequest, IncorporationToolAction>();

            //Response
            CreateMap<MBCar, MBCarResponse>();
            CreateMap<IncorporationToolAction, IncorporationActionResponse>();
            CreateMap<ActionStatusEnums, StatusResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (long)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetDescription()));
        }
    }
}
