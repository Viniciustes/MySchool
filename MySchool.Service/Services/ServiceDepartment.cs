using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceDepartment : Service<Department>, IServiceDepartment
    {
        public ServiceDepartment(IRepositoryDepartment repositoryDepartment) : base(repositoryDepartment)
        {
        }
    }
}
