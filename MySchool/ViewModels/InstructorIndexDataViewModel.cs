using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class InstructorIndexDataViewModel
    {
        public InstructorIndexDataViewModel(IEnumerable<InstructorViewModel> instructorViewModels)
        {
            InstructorsViewModels = instructorViewModels;
        }

        public IEnumerable<CourseViewModel> CourseViewModels { get; set; }

        public IEnumerable<EnrollmentViewModel> EnrollmentViewModels { get; set; }

        public IEnumerable<InstructorViewModel> InstructorsViewModels { get; set; }
    }
}