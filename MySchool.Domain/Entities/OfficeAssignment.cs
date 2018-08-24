namespace MySchool.Domain.Entities
{
    public class OfficeAssignment 
    {
        public OfficeAssignment(int instructorID, string location)
        {
            InstructorID = instructorID;
            Location = location;
        }

        public int InstructorID { get; private set; }

        public string Location { get; private set; }

        public Instructor Instructor { get; set; }
    }
}