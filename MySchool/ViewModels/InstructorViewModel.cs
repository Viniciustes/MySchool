using MySchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MySchool.ViewModels
{
    public class InstructorViewModel
    {
        public InstructorViewModel()
        {
            CourseAssignmentViewModels = new List<CourseAssignmentViewModel>();
        }

        public InstructorViewModel(Instructor instructor)
        {
            Id = instructor.Id;
            FirstName = instructor.FirstName;
            LastName = instructor.LastName;
            HireDate = instructor.HireDate;

            OfficeAssignmentViewModel = new OfficeAssignmentViewModel(instructor.Id, instructor.OfficeAssignment?.Location);

            CourseAssignmentViewModels = new List<CourseAssignmentViewModel>();

            CourseAssignmentViewModels =
                 instructor.CourseAssignments.Select
                            (
                                course => new CourseAssignmentViewModel(course.CourseId, course.InstructorId, new CourseViewModel(course.CourseId, course.Course.Title, course.Course.Credits, course.Course.DepartmentId, new DepartmentViewModel(course.Course.Department.Name)))
                            )
                        .ToList();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Display(Name = "Cursos")]
        public ICollection<CourseAssignmentViewModel> CourseAssignmentViewModels { get; set; }

        [Display(Name = "Departamento")]
        public OfficeAssignmentViewModel OfficeAssignmentViewModel { get; set; }
    }
}