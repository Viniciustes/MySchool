using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        [Display(Name = "Departamento")]
        public DepartmentViewModel DepartmentViewModel { get; set; }

        public ICollection<EnrollmentViewModel> EnrollmentViewModels { get; set; }
    }
}