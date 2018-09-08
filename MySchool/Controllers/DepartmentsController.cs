using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceDepartment _serviceDepartment;
        private readonly IServiceInstructor _serviceInstructor;

        public DepartmentsController(IMapper mapper, IServiceDepartment serviceDepartment, IServiceInstructor serviceInstructor)
        {
            _mapper = mapper;
            _serviceDepartment = serviceDepartment;
            _serviceInstructor = serviceInstructor;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var departmentsViewModel = await GetAllDepartmentsPaginated(sortOrder, currentFilter, searchString);

            return View(PaginatedListViewModel<DepartmentViewModel>.CreateAsync(departmentsViewModel, page ?? 1));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                NotFound();

            var department = await _serviceDepartment.GetByIdAsNoTrackingAsync((int)id);

            return View("~/Views/Departments/Details.cshtml");

        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var departmentViewModel = new DepartmentViewModel();

            ViewData["Instructor"] = new SelectList(await _serviceInstructor.GetAllAsync(), "Id", "FullName", departmentViewModel.InstructorId);

            return View();
        }

        #region private methods
        private async Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsPaginated(string sortOrder, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (string.IsNullOrEmpty(searchString))
                searchString = currentFilter;

            var departments = await _serviceDepartment.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
                departments = departments.Where(x => x.Name.ToLower().Contains(searchString.ToLower()));

            switch (sortOrder)
            {
                case "name_desc":
                    departments = departments.OrderByDescending(x => x.Name);
                    break;
                case "Date":
                    departments = departments.OrderBy(x => x.StartDate);
                    break;
                case "date_desc":
                    departments = departments.OrderByDescending(x => x.StartDate);
                    break;
                default:
                    departments = departments.OrderBy(x => x.Name);
                    break;
            }

            return _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
        }
        #endregion
    }
}