using MySchool.Domain.Entities;
using System.Threading.Tasks;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositoryInstructor : IRepository<Instructor>
    {
        Task Delete(int id);
    }
}
