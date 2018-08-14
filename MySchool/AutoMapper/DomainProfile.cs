using AutoMapper;
using MySchool.Domain.Entities;
using MySchool.ViewModels;

namespace MySchool.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}
