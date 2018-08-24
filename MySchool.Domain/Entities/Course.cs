using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Course : BasicEntity
    {
        public Course(string title, int credits, int departmentId)
        {
            Title = title;
            Credits = credits;
            DepartmentId = departmentId;
        }

        public string Title { get; private set; }

        public int Credits { get; private set; }
        
        public int DepartmentId { get; private set; }

        public Department Department { get; private set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}