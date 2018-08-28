using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;
using System.Linq;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryDepartment : Repository<Department>, IRepositoryDepartment
    {
        public RepositoryDepartment(MySchoolContext mySchoolContext) : base(mySchoolContext)
        {
        }
    }
}
