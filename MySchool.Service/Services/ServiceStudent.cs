﻿using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceStudent : Service<Student>, IServiceStudent
    {
        public ServiceStudent(IRepositoryStudent repositoryStudent) : base(repositoryStudent)
        {
        }
    }
}