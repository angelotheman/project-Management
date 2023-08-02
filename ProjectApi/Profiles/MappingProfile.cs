using AutoMapper;
using ProjectApi.Models;
using ProjectApi.Models.DTO;

namespace ProjectApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, ReportInputDTO>();
        }
    }
}
