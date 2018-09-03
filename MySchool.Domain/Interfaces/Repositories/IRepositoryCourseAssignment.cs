using MySchool.Domain.Entities;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositoryCourseAssignment
    {
        void Delete(CourseAssignment courseAssignment);
    }
}