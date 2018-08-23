namespace MySchool.Domain.Entities
{
    public class OfficeAssignment : BasicEntity
    {
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}