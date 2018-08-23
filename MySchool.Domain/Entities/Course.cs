using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Course : BasicEntity
    {
        public string Title { get; set; }

        public int Credits { get; set; }
        
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}