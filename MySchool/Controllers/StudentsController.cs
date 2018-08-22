using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Entities;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var students = await _serviceStudent.GetStudentListAsNoTrackingAsyncPaginated(sortOrder, searchString);
            var studentsViewModel = _mapper.Map<IEnumerable<StudentViewModel>>(students);

            return View(studentsViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetStudentByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EnrollmentDate")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentViewModel);
                await _serviceStudent.AddAsync(student);

                return RedirectToAction(nameof(Index));
            }

            return View(studentViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetStudentByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("FirstName,LastName,EnrollmentDate,Id")] StudentViewModel studentViewModel)
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

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return NotFound();

            var studentsViewModel = await GetStudentByIdAsNoTrackingAsync((int)id);

            return View(studentsViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _serviceStudent.GetStudentByIdAsNoTrackingAsync(id);

            await _serviceStudent.DeleteAsync(student);

            return RedirectToAction(nameof(Index));
        }

        private async Task<StudentViewModel> GetStudentByIdAsNoTrackingAsync(int id)
        {
            var student = await _serviceStudent.GetStudentByIdAsNoTrackingAsync(id);

            var studentsViewModel = _mapper.Map<StudentViewModel>(student);

            return studentsViewModel;
        }
    }
}