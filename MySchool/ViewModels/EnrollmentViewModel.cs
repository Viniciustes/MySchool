using MySchool.Domain.Enums;

namespace MySchool.ViewModels
{
    public class EnrollmentViewModel
    {
        public Grade? Grade { get; set; }
        public CourseViewModel CourseViewModel { get; set; }
    }
}