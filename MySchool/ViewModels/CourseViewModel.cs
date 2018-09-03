using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class CourseViewModel
    {
        //Para utilizacão do Auto Mapper necessita do construtor abaixo.
        public CourseViewModel(){}

        public CourseViewModel(int id, string title, int credits, int departmentId, DepartmentViewModel departmentViewModel)
        {
            Id = id;
            Title = title;
            Credits = credits;
            DepartmentId = departmentId;
            DepartmentViewModel = departmentViewModel;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        [Display(Name = "Departamento")]
        public DepartmentViewModel DepartmentViewModel { get; set; }

        public ICollection<EnrollmentViewModel> EnrollmentViewModels { get; set; }
    }
}