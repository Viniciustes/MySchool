using MySchool.Domain.Entities;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IServiceInstructor : IService<Instructor>
    {
        Task Delete(int id);
    }
}
