using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryInstructor : Repository<Instructor>, IRepositoryInstructor
    {
        public RepositoryInstructor(MySchoolContext context) : base(context) { }
    }
}
