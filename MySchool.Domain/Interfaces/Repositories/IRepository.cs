using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepository<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
    }
}
