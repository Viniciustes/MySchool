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
            StartDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Nome do departamento é obrigatório!")]
        public string Name { get; set; }

        [Display(Name = "Orçamento")]
        [Required(ErrorMessage = "Orçamento do departamento é obrigatório!")]
        public decimal Budget { get; set; }

        public DateTime StartDate { get; }

        public int? InstructorId { get; set; }

        [Display(Name = "Administrador do departamento")]
        public InstructorViewModel Administrator { get; set; }

        public ICollection<CourseViewModel> CourseViewModels { get; set; }

        public byte[] RowVersion { get; set; }
    }
}