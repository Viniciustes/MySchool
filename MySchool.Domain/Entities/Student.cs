using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Student : BasicEntity
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            EnrollmentDate = DateTime.Now;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime EnrollmentDate { get; private set; }

        public ICollection<Enrollment> Enrollments { get; private set; }
    }
}