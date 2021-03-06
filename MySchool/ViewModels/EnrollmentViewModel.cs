﻿using MySchool.Domain.Enums;

namespace MySchool.ViewModels
{
    public class EnrollmentViewModel
    {
        public Grade? Grade { get; set; }

        public string CourseTitle { get; set; }

        public StudentViewModel StudentViewModel { get; set; }
    }
}