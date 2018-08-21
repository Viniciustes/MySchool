using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;
using System.Threading.Tasks;

namespace MySchool.Service.Services
{
    public class ServiceStudent : Service<Student>, IServiceStudent
    {
        public ServiceStudent(IRepositoryStudent repository) : base(repository) { }

        public Task<Student> GetStudentByIdAsNoTrackingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
