namespace MySchool.Domain.Entities
{
    public class CourseAssignment
    {
        public CourseAssignment(int courseId, int instructorId)
        {
            CourseId = courseId;
            InstructorId = instructorId;
        }

        public int CourseId { get; private set; }

        public Course Course { get; set; }

        public int InstructorId { get; private set; }

        public Instructor Instructor { get; set; }
    }
}