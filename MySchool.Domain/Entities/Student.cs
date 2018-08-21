using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Student : BasicEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
