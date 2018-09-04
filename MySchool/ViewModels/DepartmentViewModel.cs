using MySchool.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MySchool.ViewModels
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel(string name)
        {
            Name = name;
        }
       
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; private set; }

        public int? InstructorId { get; set; }

        public InstructorViewModel Administrator { get; set; }

        public ICollection<CourseViewModel> CourseViewModels { get; set; }
    }
}