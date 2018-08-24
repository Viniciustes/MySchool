using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class InstructorIndexData
    {
        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Instructor> Instructors { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
