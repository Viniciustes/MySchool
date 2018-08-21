using System.Collections.Generic;

namespace MySchool.Domain.Entities
{
    public class Course : BasicEntity
    {
        public string Title { get; set; }

        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}