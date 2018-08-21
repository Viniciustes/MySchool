using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome do produto é obrigatório.")]
        public string LastName { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName => FirstName + " " + LastName;

        [Display(Name = "Data de cadastro")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Matrículas")]
        public IList<EnrollmentViewModel> EnrollmentViewModels { get; set; }
    }
}
