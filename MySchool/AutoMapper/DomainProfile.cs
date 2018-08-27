using AutoMapper;
using MySchool.Domain.Entities;
using MySchool.ViewModels;

namespace MySchool.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(x => x.DepartmentViewModel, opt => opt.MapFrom(src => src.Department))
                .ReverseMap();

            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.EnrollmentViewModels, opt => opt.MapFrom(src => src.Enrollments))
                .ReverseMap();

            CreateMap<Enrollment, EnrollmentViewModel>()
                .ReverseMap();

            CreateMap<Instructor, InstructorViewModel>()
                .ForMember(x => x.OfficeAssignmentViewModel, opt => opt.MapFrom(src => src.OfficeAssignment))
                .ReverseMap();
        }
    }
}