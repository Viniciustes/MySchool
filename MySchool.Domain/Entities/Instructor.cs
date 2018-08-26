using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Instructor : BasicEntity
    {
        public Instructor(string firstName, string lastName, DateTime hireDate)
        {
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
        }

        public string FirstName { get;  private set; }

        public string LastName { get;  private set; }

        public DateTime HireDate { get; private set; }

        public string FullName { get => FirstName + " " + LastName; }

        // Tabela many for many 
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        // Tabela one to many and null 
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}