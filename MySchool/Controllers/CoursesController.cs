using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySchool.Domain.Entities;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceCourse _serviceCourse;
        private readonly IServiceDepartment _serviceDepartment;

        public CoursesController(IMapper mapper, IServiceCourse serviceCourse, IServiceDepartment serviceDepartment)
        {
            _mapper = mapper;
            _serviceCourse = serviceCourse;
            _serviceDepartment = serviceDepartment;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var courses = await _serviceCourse.GetAllAsync();

            var coursesViewModel = _mapper.Map<IEnumerable<CourseViewModel>>(courses);

            return View(PaginatedListViewModel<CourseViewModel>.CreateAsync(coursesViewModel, page ?? 1));
        }

        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId", "Credits", "DepartmentId", "Title")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseViewModel);

                await _serviceCourse.AddAsync(course);

                return RedirectToAction(nameof(Index));
            }

            PopulateDepartmentsDropDownList(courseViewModel.DepartmentId);

            return View(courseViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _serviceCourse.GetByIdAsNoTrackingAsync((int)id);

            if (course == null)
                return NotFound();

            var courseViewModel = _mapper.Map<CourseViewModel>(course);

            PopulateDepartmentsDropDownList(courseViewModel.DepartmentId);

            return View(courseViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("CourseId", "Credits", "DepartmentId", "Title")] CourseViewModel courseViewModel)
        {
            if (id != courseViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseViewModel);

                await _serviceCourse.UpdateAsync(course);

                return RedirectToAction(nameof(Index));
            }

            PopulateDepartmentsDropDownList(courseViewModel.DepartmentId);

            return View(courseViewModel);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _serviceDepartment.GetAllIQuerableAsNoTracking();

            ViewBag.DepartmentId = new SelectList(departmentsQuery, "DepartmentId", "Name", selectedDepartment);
        }
    }
}