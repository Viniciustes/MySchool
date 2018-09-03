using MySchool.Domain.Entities;

namespace MySchool.Service.Interfaces
{
    public interface IServiceCourseAssignment 
    {
        void Delete(CourseAssignment courseAssignment);
    }
}