using AutoMapper;
using MySchool.Domain.Entities;
using MySchool.ViewModels;
using System.Linq;

namespace MySchool.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(vwm => vwm.EnrollmentViewModels, opt => opt.MapFrom(src => src.Enrollments))
                .ReverseMap();

            CreateMap<Enrollment, EnrollmentViewModel>().ReverseMap();
        }
    }
}
