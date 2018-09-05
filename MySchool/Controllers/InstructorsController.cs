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
    public class InstructorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceCourse _serviceCourse;
        private readonly IServiceInstructor _serviceInstructor;
        private readonly IServiceCourseAssignment _serviceCourseAssignment;

        public InstructorsController(IMapper mapper, IServiceCourse serviceCourse, IServiceInstructor serviceInstructor, IServiceCourseAssignment serviceCourseAssignment)
        {
            _mapper = mapper;
            _serviceCourse = serviceCourse;
            _serviceInstructor = serviceInstructor;
            _serviceCourseAssignment = serviceCourseAssignment;
        }

        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var instructors = await _serviceInstructor.GetAllAsync();

            var instructorsViewModel = _mapper.Map<IEnumerable<InstructorViewModel>>(instructors);

            var instructorIndexDataViewModel = new InstructorIndexDataViewModel(instructorsViewModel);

            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;

                var instructor = instructorIndexDataViewModel.InstructorsViewModels.Single(x => x.Id == id.Value);

                instructorIndexDataViewModel.CourseViewModels = instructor.CourseAssignmentViewModels.Select(x => x.CourseViewModel);
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;

                instructorIndexDataViewModel.EnrollmentViewModels = instructorIndexDataViewModel.CourseViewModels.Where(x => x.Id == courseId.Value).Single().EnrollmentViewModels;
            }

            return View(instructorIndexDataViewModel);
        }

        public IActionResult Create()
        {
            var instructorViewModel = new InstructorViewModel();

            PopulateAssignedCourseData(instructorViewModel);

            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("FirstName, HireDate, LastName, OfficeAssignmentViewModel")] InstructorViewModel instructorViewModel, string[] selectedCourses)
        {
            if (selectedCourses.Any())
            {
                instructorViewModel.CourseAssignmentViewModels = selectedCourses
                    .Select(
                        course => new CourseAssignmentViewModel(int.Parse(course), instructorViewModel.Id)
                    ).ToList();
            }

            if (ModelState.IsValid)
            {
                var instructor = _mapper.Map<Instructor>(instructorViewModel);

                await _serviceInstructor.AddAsync(instructor);

                return RedirectToAction(nameof(Index));
            }

            PopulateAssignedCourseData(instructorViewModel);

            return View(instructorViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var instructorViewModel = await GetInstructorViewModelById(id);

            PopulateAssignedCourseData(instructorViewModel);

            return View(instructorViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var instructorViewModel = await GetInstructorViewModelById(id);

            PopulateAssignedCourseData(instructorViewModel);

            return View(instructorViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, [Bind("FirstName", "LastName", "HireDate", "OfficeAssignmentViewModel")] InstructorViewModel instructorViewModel, string[] selectedCourses)
        {
            if (id == null) NotFound();

            var instructor = await _serviceInstructor.GetByIdAsync((int)id);

            instructor = instructor.UpdateInstructor(instructorViewModel.FirstName, instructorViewModel.LastName, instructorViewModel.HireDate, instructorViewModel.OfficeAssignmentViewModel.Location);

            if (await TryUpdateModelAsync(
                instructor,
                "Instructor",
                i => i.FirstName, i => i.LastName, i => i.HireDate, i => i.OfficeAssignment))
            {
                if (string.IsNullOrWhiteSpace(instructor.OfficeAssignment?.Location))
                {
                    instructor.OfficeAssignment = null;
                }

                UpdateInstructorCourses(selectedCourses, instructor);

                await _serviceInstructor.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            UpdateInstructorCourses(selectedCourses, instructor);

            PopulateAssignedCourseData(instructorViewModel);

            return View(instructorViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var instructorViewModel = await GetInstructorViewModelById(id);

            return View(instructorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceInstructor.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        #region private methods
        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructor)
        {
            if (!selectedCourses.Any())
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);

            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.Course.Id));

            var couses = _serviceCourse.GettAll();

            foreach (var course in couses)
            {
                if (selectedCoursesHS.Contains(course.Id.ToString()))
                {
                    if (!instructorCourses.Contains(course.Id))
                    {
                        instructor.CourseAssignments.Add(new CourseAssignment(course.Id, instructor.Id));
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.Id))
                    {
                        var courseAssignment = instructor.CourseAssignments.SingleOrDefault(i => i.CourseId == course.Id);
                        _serviceCourseAssignment.Delete(courseAssignment);
                    }
                }
            }
        }

        private void PopulateAssignedCourseData(InstructorViewModel instructorViewModel)
        {
            var courses = _serviceCourse.GettAll();

            var instructorCourses = new HashSet<int>(instructorViewModel.CourseAssignmentViewModels.Select(x => x.CourseId));

            ViewData["Courses"] =
               courses.Select(
                    course => new AssignedCourseDataViewModel
                    {
                        CourseId = course.Id,
                        Title = course.Title,
                        Assigned = instructorCourses.Contains(course.Id)
                    }
                    ).ToList();
        }

        private async Task<InstructorViewModel> GetInstructorViewModelById(int? id)
        {
            if (id == null) NotFound();

            var instructor = await _serviceInstructor.GetByIdAsNoTrackingAsync((int)id);

            if (instructor == null) NotFound();

            return _mapper.Map<InstructorViewModel>(instructor);
        }
        #endregion
    }
}