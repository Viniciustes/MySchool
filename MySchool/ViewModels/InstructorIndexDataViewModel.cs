using MySchool.Domain.Entities;
using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class InstructorIndexDataViewModel
    {
        //TODO Não expor entidades de dominio diretamente na camada de apresentação.

        public IEnumerable<Course> CoursesViewModel { get; set; }

        public IEnumerable<InstructorViewModel> InstructorsViewModel { get; set; }

        public IEnumerable<Enrollment> EnrollmentsViewModel { get; set; }
    }
}