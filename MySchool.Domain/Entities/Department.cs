using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Department : BasicEntity
    {
        public Department(string name, decimal budget, DateTime startDate, int? instructorID)
        {
            Name = name;
            Budget = budget;
            StartDate = startDate;
            InstructorID = instructorID;
        }

        public string Name { get; private set; }

        public decimal Budget { get; private set; }

        public DateTime StartDate { get; private set; }

        public int? InstructorID { get; private set; }

        public Instructor Administrator { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
