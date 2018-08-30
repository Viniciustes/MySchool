using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Entities;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceCourse _serviceCourse;
        private readonly IServiceInstructor _serviceInstructor;

        public InstructorsController(IMapper mapper, IServiceCourse serviceCourse, IServiceInstructor serviceInstructor)
        {
            _mapper = mapper;
            _serviceCourse = serviceCourse;
            _serviceInstructor = serviceInstructor;
        }

        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var instructors = await _serviceInstructor.GetAllAsync();

            var instructorsViewModel = _mapper.Map<IEnumerable<InstructorViewModel>>(instructors);

            var instructorIndexDataViewModel = new InstructorIndexDataViewModel
            {
                InstructorsViewModel = instructorsViewModel
            };

            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;

                var instructor = instructorIndexDataViewModel.InstructorsViewModel.Single(x => x.Id == id.Value);

                instructorIndexDataViewModel.CoursesViewModel = instructor.CourseAssignments.Select(x => x.Course);
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;

                instructorIndexDataViewModel.EnrollmentsViewModel = instructorIndexDataViewModel.CoursesViewModel.Where(x => x.Id == courseId.Value).Single().Enrollments;
            }

            return View(instructorIndexDataViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                NotFound();

            var instructor = await _serviceInstructor.GetByIdAsNoTrackingAsync((int)id);

            if (instructor == null)
                NotFound();

            PopulateAssignedCourseData(instructor);

            var instructorViewModel = _mapper.Map<InstructorViewModel>(instructor);

            return View(instructorViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Id", "FirstName", "LastName", "HireDate", "OfficeAssignmentViewModel")] InstructorViewModel instructorViewModel)
        {
            if (id != instructorViewModel.Id)
                NotFound();

            if (ModelState.IsValid)
            {
                var officeAssignment = new OfficeAssignment(instructorViewModel.Id, instructorViewModel.OfficeAssignmentViewModel.Location);

                var instructor = new Instructor(instructorViewModel.Id, instructorViewModel.FirstName, instructorViewModel.LastName, instructorViewModel.HireDate, officeAssignment);

                await _serviceInstructor.UpdateAsync(instructor);

                return RedirectToAction(nameof(Index));
            }

            return View(instructorViewModel);
        }

        #region private methods
        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourse = _serviceCourse.GettAll();

            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(x => x.CourseId));

            var assignedCourseDataViewModel = new List<AssignedCourseDataViewModel>();

            foreach (var course in allCourse)
            {
                assignedCourseDataViewModel.Add(new AssignedCourseDataViewModel
                {
                    CourseId = course.Id,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.Id)
                });
            }

            ViewData["Courses"] = assignedCourseDataViewModel;
        }
        #endregion
    }
}