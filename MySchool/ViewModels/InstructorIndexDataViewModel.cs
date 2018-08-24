using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class InstructorIndexDataViewModel
    {
        public IEnumerable<CourseViewModel> CoursesViewModel { get; set; }

        public IEnumerable<InstructorViewModel> InstructorsViewModel { get; set; }

        public IEnumerable<EnrollmentViewModel> EnrollmentsViewModel { get; set; }
    }
}
