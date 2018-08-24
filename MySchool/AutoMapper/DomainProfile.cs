using AutoMapper;
using MySchool.Domain.Entities;
using MySchool.ViewModels;

namespace MySchool.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.EnrollmentViewModels, opt => opt.MapFrom(src => src.Enrollments))
                .ReverseMap();

            CreateMap<Enrollment, EnrollmentViewModel>()
                .ReverseMap();

            CreateMap<Course, CourseViewModel>()
                .ForMember(x => x.DepartmentViewModel, opt => opt.MapFrom(src => src.Department))
                .ReverseMap();

            CreateMap<InstructorIndexData, InstructorIndexDataViewModel>()
                .ForMember(x => x.CoursesViewModel, opt => opt.MapFrom(src => src.Courses))
                .ForMember(x => x.EnrollmentsViewModel, opt => opt.MapFrom(src => src.Enrollments))
                .ForMember(x => x.InstructorsViewModel, opt => opt.MapFrom(src => src.Instructors))
                .ReverseMap();
        }
    }
}