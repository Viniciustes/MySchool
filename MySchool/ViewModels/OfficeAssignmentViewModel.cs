using System.ComponentModel.DataAnnotations;

namespace MySchool.ViewModels
{
    public class OfficeAssignmentViewModel
    {
        public OfficeAssignmentViewModel() { }

        public OfficeAssignmentViewModel(int instructorId, string location)
        {
            InstructorId = instructorId;
            Location = location;
        }

        public int InstructorId { get; set; }

        [Display(Name = "Escritório")]
        public string Location { get; set; }
    }
}