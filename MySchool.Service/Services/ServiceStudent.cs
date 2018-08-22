using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;
using System.Threading.Tasks;

namespace MySchool.Service.Services
{
    public class ServiceStudent : Service<Student>, IServiceStudent
    {
        private readonly IRepositoryStudent _repositoryStudent;

        public ServiceStudent(IRepositoryStudent repositoryStudent) : base(repositoryStudent)
        {
            _repositoryStudent = repositoryStudent;
        }

        public async Task<Student> GetStudentByIdAsNoTrackingAsync(int id)
        {
            return await _repositoryStudent.GetStudentByIdAsNoTrackingAsync(id);
        }
    }
}