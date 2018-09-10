using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Department : BasicEntity
    {
        public Department() { }

        public Department(string name, decimal budget, DateTime startDate, int? instructorId)
        {
            Name = name;
            Budget = budget;
            StartDate = startDate;
            InstructorId = instructorId;
        }

        public string Name { get; private set; }

        public decimal Budget { get; private set; }

        public DateTime StartDate { get; private set; }

        public int? InstructorId { get; set; }

        public Instructor Administrator { get; set; }

        public ICollection<Course> Courses { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
