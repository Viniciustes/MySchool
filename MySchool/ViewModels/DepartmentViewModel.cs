using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel() { }

        public DepartmentViewModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; private set; }

        public int? InstructorId { get; set; }

        [Display(Name = "Administrador do departamento")]
        public InstructorViewModel Administrator { get; set; }

        public ICollection<CourseViewModel> CourseViewModels { get; set; }

        public byte[] RowVersion { get; set; }
    }
}