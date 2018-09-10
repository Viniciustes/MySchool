using System;
using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            EnrollmentDate = DateTime.Now;
        }

        public DateTime EnrollmentDate { get; private set; }

        public ICollection<Enrollment> Enrollments { get; private set; }
    }
}