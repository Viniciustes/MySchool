using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryStudent : Repository<Student>, IRepositoryStudent
    {
        public RepositoryStudent(MySchoolContext context) : base(context) { }
    }
}
