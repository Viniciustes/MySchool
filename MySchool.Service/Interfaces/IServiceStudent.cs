using MySchool.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IServiceStudent : IService<Student>
    {
        Task<Student> GetStudentByIdAsNoTrackingAsync(int id);
        Task<IList<Student>> GetStudentListAsNoTrackingAsyncPaginated(string sortOrder, string searchString);
    }
}