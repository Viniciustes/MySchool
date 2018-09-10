using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MySchoolContext _context;
        private readonly IServiceDepartment _serviceDepartment;
        private readonly IServiceInstructor _serviceInstructor;

        public DepartmentsController(IMapper mapper, IServiceDepartment serviceDepartment, IServiceInstructor serviceInstructor, MySchoolContext context)
        {
            _mapper = mapper;
            _context = context;
            _serviceDepartment = serviceDepartment;
            _serviceInstructor = serviceInstructor;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var departmentsViewModel = await GetAllDepartmentsPaginated(sortOrder, currentFilter, searchString);

            return View(PaginatedListViewModel<DepartmentViewModel>.CreateAsync(departmentsViewModel, page ?? 1));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) NotFound();

            const string query = "SELECT * FROM Department WHERE Id = {0}";

            var department = await _context.Departments
                .FromSql(query, id)
                .Include(d => d.Administrator)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (department == null) NotFound();

            return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await GetDepartmentViewModelById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
                return NotFound();

            var departmentToUpdate = await _context.Departments.Include(i => i.Administrator).SingleOrDefaultAsync(m => m.Id == id);

            if (departmentToUpdate == null)
            {
                var deletedDepartment = new Department();

                await TryUpdateModelAsync(deletedDepartment);

                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");

                await GetViewDataInstructor(deletedDepartment.InstructorId);

                return View(deletedDepartment);
            }

            _context.Entry(departmentToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync(
                departmentToUpdate,
                "",
                s => s.Name, s => s.StartDate, s => s.Budget, s => s.InstructorId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Department)databaseEntry.ToObject();

                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }

                        if (databaseValues.Budget != clientValues.Budget)
                        {
                            ModelState.AddModelError("Budget", $"Current value: {databaseValues.Budget:c}");
                        }

                        if (databaseValues.StartDate != clientValues.StartDate)
                        {
                            ModelState.AddModelError("StartDate", $"Current value: {databaseValues.StartDate:d}");
                        }

                        if (databaseValues.InstructorId != clientValues.InstructorId)
                        {
                            var databaseInstructor = await _context.Instructors.SingleOrDefaultAsync(i => i.Id == databaseValues.InstructorId);
                            ModelState.AddModelError("InstructorID", $"Current value: {databaseInstructor?.FullName}");
                        }

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        departmentToUpdate.RowVersion = databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }

            await GetViewDataInstructor(departmentToUpdate.InstructorId);

            return View(departmentToUpdate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await GetDepartmentViewModelById(id));
        }

        public async Task<IActionResult> Create()
        {
            await GetViewDataInstructor();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Budget", "InstructorId")]DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid) return View(departmentViewModel);

            var department = _mapper.Map<Department>(departmentViewModel);

            await _serviceDepartment.AddAsync(department);

            return RedirectToAction(nameof(Index));
        }

        #region private methods
        private async Task GetViewDataInstructor(int? instructorId = null)
        {
            ViewData["Instructor"] = new SelectList(await _serviceInstructor.GetAllAsync(), "Id", "FullName", instructorId);
        }

        private async Task<DepartmentViewModel> GetDepartmentViewModelById(int id)
        {
            if (id == 0) NotFound();

            var department = await _serviceDepartment.GetByIdAsNoTrackingAsync(id);

            if (department == null) NotFound();

            return _mapper.Map<DepartmentViewModel>(department);
        }

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