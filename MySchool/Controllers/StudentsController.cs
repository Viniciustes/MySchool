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

        public async Task<IActionResult> Index()
        {
            var students = await _serviceStudent.GetAllAsync();
            var studentsViewModel = _mapper.Map<IEnumerable<StudentViewModel>>(students);
            return View(studentsViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _serviceStudent.GetStudentByIdAsNoTrackingAsync((int)id);

            if (student == null)
                return NotFound();

            var studentsViewModel = _mapper.Map<StudentViewModel>(student);

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
            return await Details(id);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
                return NotFound();

            var studentToUpdate = await _serviceStudent.GetByIdAsync((int)id);

            //if (await TryUpdateModelAsync<Student>(
            //    studentToUpdate,
            //    "",
            //    s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch (DbUpdateException /* ex */)
            //    {
            //        //Log the error (uncomment ex variable name and write a log.)
            //        ModelState.AddModelError("", "Unable to save changes. " +
            //            "Try again, and if the problem persists, " +
            //            "see your system administrator.");
            //    }
            //}
            return View(studentToUpdate);
        }
    }
}