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

            CreateMap<OfficeAssignment, OfficeAssignmentViewModel>()
                .ReverseMap();

            CreateMap<CourseAssignment, CourseAssignmentViewModel>()
                .ForMember(x => x.CourseViewModel, opt => opt.MapFrom(src => src.Course))
                .ForMember(x => x.InstructorViewModel, opt => opt.MapFrom(src => src.Instructor))
                .ReverseMap();

            CreateMap<Instructor, InstructorViewModel>()
                .ForMember(x => x.OfficeAssignmentViewModel, opt => opt.MapFrom(src => src.OfficeAssignment))
                .ForMember(y => y.CourseAssignmentViewModels, opt => opt.MapFrom(src => src.CourseAssignments))
                .ReverseMap();

            CreateMap<Department, DepartmentViewModel>()
              .ForMember(x => x.CourseViewModels, opt => opt.MapFrom(src => src.Courses))
              .ReverseMap();
        }
    }
}