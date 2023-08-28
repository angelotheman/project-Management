using AutoMapper;
using ProjectApi.Models.DTO;
using ProjectApi.Models.Entities;

namespace ProjectApi.Profiles
{
    public class ReportImageMappingProfile : Profile
    {
        public ReportImageMappingProfile()
        {
            CreateMap<ReportImage, ReportImageDTO>().ReverseMap();
            CreateMap<ReportImage, CreateReportImageDTO>().ReverseMap();
            CreateMap<ReportImage, UpdateReportImageDTO>().ReverseMap();
        }
    }
}
