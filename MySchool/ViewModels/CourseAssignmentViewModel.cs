namespace MySchool.ViewModels
{
    public class CourseAssignmentViewModel
    {
        public CourseAssignmentViewModel(int courseId, int instructorId)
        {
            CourseId = courseId;
            InstructorId = instructorId;
        }

        public CourseAssignmentViewModel(int courseId, int instructorId, CourseViewModel courseViewModel)
        {
            CourseId = courseId;
            InstructorId = instructorId;
            CourseViewModel = courseViewModel;
        }

        public int CourseId { get; private set; }

        public int InstructorId { get; private set; }

        public CourseViewModel CourseViewModel { get; set; }

        public InstructorViewModel InstructorViewModel { get; set; }
    }
}
