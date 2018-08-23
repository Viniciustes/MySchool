using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Department : BasicEntity
    {
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        public Instructor Administrator { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
