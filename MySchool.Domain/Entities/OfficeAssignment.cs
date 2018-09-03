namespace MySchool.Domain.Entities
{
    public class OfficeAssignment
    {
        public OfficeAssignment(int instructorId, string location)
        {
            InstructorId = instructorId;
            Location = location;
        }

        public int InstructorId { get; private set; }

        public string Location { get; private set; }

        public Instructor Instructor { get; set; }
    }
}