using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public DepartmentsController(IMapper mapper, IServiceDepartment serviceDepartment)
        {
            _mapper = mapper;
            _serviceDepartment = serviceDepartment;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var departmentsViewModel = await GetAllDepartmentsPaginated(sortOrder, currentFilter, searchString, page);

            return View(PaginatedListViewModel<DepartmentViewModel>.CreateAsync(departmentsViewModel, page ?? 1));
        }

        #region private methods
        private async Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsPaginated(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (!string.IsNullOrEmpty(searchString))
                page = 1;
            else
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