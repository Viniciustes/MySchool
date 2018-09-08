using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Entities;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceStudent _serviceStudent;

        public StudentsController(IMapper mapper, IServiceStudent serviceStudent)
        {
            _mapper = mapper;
            _serviceStudent = serviceStudent;
        }

        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var studentsViewModel = GetAllStudentsPaginated(sortOrder, currentFilter, searchString);
            return View(PaginatedListViewModel<StudentViewModel>.CreateAsync(studentsViewModel, page ?? 1));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid) return View(studentViewModel);

            var student = _mapper.Map<Student>(studentViewModel);

            await _serviceStudent.AddAsync(student);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("FirstName,LastName,Id")] StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentViewModel);

                await _serviceStudent.UpdateAsync(student);

                return RedirectToAction(nameof(Index));
            }

            return View(studentViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _serviceStudent.GetByIdAsync(id);

            await _serviceStudent.DeleteAsync(student);

            return RedirectToAction(nameof(Index));
        }

        #region private methods
        private async Task<StudentViewModel> GetByIdAsNoTrackingAsync(int id)
        {
            var student = await _serviceStudent.GetByIdAsNoTrackingAsync(id);

            var studentsViewModel = _mapper.Map<StudentViewModel>(student);

            return studentsViewModel;
        }

        private IEnumerable<StudentViewModel> GetAllStudentsPaginated(string sortOrder, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (string.IsNullOrEmpty(searchString))
                searchString = currentFilter;

            var students = _serviceStudent.GetAllIQuerableAsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
                students = students.Where(x => x.FirstName.ToLower().Contains(searchString.ToLower()) || x.LastName.ToLower().Contains(searchString.ToLower()));

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.FirstName);
                    break;
            }

            return _mapper.Map<IEnumerable<StudentViewModel>>(students);
        }
        #endregion
    }
}