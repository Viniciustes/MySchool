using MySchool.Domain.Entities;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IServiceStudent : IService<Student>
    {
        Task<Student> GetStudentByIdAsNoTrackingAsync(int id);
    }
}