using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceCourseAssignment : IServiceCourseAssignment
    {
        private readonly IRepositoryCourseAssignment _repositoryCourseAssignment;

        public ServiceCourseAssignment(IRepositoryCourseAssignment repositoryCourseAssignment)
        {
            _repositoryCourseAssignment = repositoryCourseAssignment;
        }

        public void Delete(CourseAssignment courseAssignment)
        {
            _repositoryCourseAssignment.Delete(courseAssignment);
        }
    }
}