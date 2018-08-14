using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome do produto é obrigatório.")]
        public string LastName { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName => FirstName + " " + LastName;
    }
}
