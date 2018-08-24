using MySchool.Domain.Enums;

namespace MySchool.Domain.Entities
{
    public class Enrollment : BasicEntity
    {
        public Enrollment(int studentId, int courseId, Grade? grade =null)
        {
            StudentId = studentId;
            CourseId = courseId;
            Grade = grade;
        }

        public int StudentId { get; private set; }

        public int CourseId { get; private set; }

        public Grade? Grade { get; private set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}