using System.Threading.Tasks;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceInstructor : Service<Instructor>, IServiceInstructor
    {
        private readonly IRepositoryInstructor _repositoryInstructor;

        public ServiceInstructor(IRepositoryInstructor repositoryInstructor) : base(repositoryInstructor)
        {
            _repositoryInstructor = repositoryInstructor;
        }

        public async Task GetCourse(Course course)
        {
            await _repositoryInstructor.GetCourse(course);
        }

        public async Task GetEnrollment(Enrollment enrollment)
        {
            await _repositoryInstructor.GetEnrollment(enrollment);
        }
    }
}