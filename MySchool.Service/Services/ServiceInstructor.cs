﻿using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class ServiceInstructor : Service<Instructor>, IServiceInstructor
    {
        public ServiceInstructor(IRepositoryInstructor repositoryInstructor) : base(repositoryInstructor) { }
    }
}