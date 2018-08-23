using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "A primeira letra deve ser maiúscula e as demais minúsculas.")]
        [StringLength(30, ErrorMessage = "O nome não pode ter mais que 30 caracteres.")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "A primeira letra deve ser maiúscula e as demais minúsculas.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres.")]
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome do produto é obrigatório.")]
        public string LastName { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName => FirstName + " " + LastName;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de cadastro")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Matrículas")]
        public IList<EnrollmentViewModel> EnrollmentViewModels { get; set; }
    }
}
