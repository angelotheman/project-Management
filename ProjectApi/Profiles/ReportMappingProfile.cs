using AutoMapper;
using ProjectApi.Models.Entities;
using ProjectApi.Models.DTO;

namespace ProjectApi.Profiles
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportDTO>().ReverseMap();
            CreateMap<Report, CreateReportDTO>().ReverseMap();
            CreateMap<Report, UpdateReportDTO>().ReverseMap();
        }
    }
}