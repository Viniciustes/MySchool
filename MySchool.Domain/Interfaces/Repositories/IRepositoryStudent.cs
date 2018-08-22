using MySchool.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositoryStudent : IRepository<Student>
    {
        Task<Student> GetStudentByIdAsNoTrackingAsync(int id);
        Task<IList<Student>> GetStudentListAsNoTrackingAsyncPaginated(string sortOrder, string searchString);
    }
}