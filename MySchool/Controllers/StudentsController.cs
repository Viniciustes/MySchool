using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}