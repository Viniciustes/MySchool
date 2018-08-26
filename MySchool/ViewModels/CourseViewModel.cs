using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public DepartmentViewModel DepartmentViewModel { get; set; }

        public ICollection<EnrollmentViewModel> EnrollmentViewModels { get; set; }
    }
}