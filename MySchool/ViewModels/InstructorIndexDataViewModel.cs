using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class InstructorIndexDataViewModel
    {
        //public InstructorIndexDataViewModel()
        //{
        //    CoursesViewModel = new List<CourseViewModel>();
        //    InstructorsViewModel = new List<InstructorViewModel>();
        //    EnrollmentsViewModel = new List<EnrollmentViewModel>();
        //}

        public IEnumerable<CourseViewModel> CoursesViewModel { get; set; }

        public IEnumerable<InstructorViewModel> InstructorsViewModel { get; set; }

        public IEnumerable<EnrollmentViewModel> EnrollmentsViewModel { get; set; }
    }
}