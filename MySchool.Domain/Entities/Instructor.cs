using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Domain.Entities
{
    public class Instructor : BasicEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string FullName { get => FirstName + " " + LastName; }

        // Tabela many for many 
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        // Tabela one to many and null 
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
