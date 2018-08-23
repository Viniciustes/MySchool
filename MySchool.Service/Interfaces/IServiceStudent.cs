using MySchool.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IServiceStudent : IService<Student>
    {
        Task<IList<Student>> GetListAsNoTrackingAsyncPaginated(string sortOrder, string searchString);
    }
}