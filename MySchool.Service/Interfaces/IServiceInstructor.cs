using MySchool.Domain.Entities;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IServiceInstructor : IService<Instructor>
    {
        Task GetCourse(Course course);
        Task GetEnrollment(Enrollment enrollment);
    }
}
