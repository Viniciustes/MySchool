using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceDepartment _serviceDepartment;

        public DepartmentsController(IMapper mapper, IServiceDepartment serviceDepartment)
        {
            _mapper = mapper;
            _serviceDepartment = serviceDepartment;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var departments = await _serviceDepartment.GetAllAsync();

            var departmentsViewModel = new List<DepartmentViewModel>();


            //new DepartmentViewModel(departm?Lh ents);


            return View(PaginatedListViewModel<DepartmentViewModel>.CreateAsync(departmentsViewModel, page ?? 1));
        }
    }
}