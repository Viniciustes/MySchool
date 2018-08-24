using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceCourse : Service<Course>, IServiceCourse
    {
        public ServiceCourse(IRepositoryCourse repositoryCourse) : base(repositoryCourse) { }
    }
}