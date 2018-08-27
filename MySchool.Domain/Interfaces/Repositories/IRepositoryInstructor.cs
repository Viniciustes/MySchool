using MySchool.Domain.Entities;
using System.Threading.Tasks;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepositoryInstructor : IRepository<Instructor>
    {
        Task GetCourse(Course course);
        Task GetEnrollment(Enrollment enrollment);
    }
}
