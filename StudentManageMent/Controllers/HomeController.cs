using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManageMent.Models;
using StudentManageMent.ViewModels;

namespace StudentManageMent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> student = _studentRepository.GetAllStudent();
            return View(student);
            //return "this is HomeController to Index method!";
        }

        public IActionResult Detail(int id)
        {
            //Student model = _studentRepository.GetStudent(1);

            //ViewData["title"] = "学生详情";
            //ViewData["Student"] = model;
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel()
            {
                student = _studentRepository.GetStudent(id),
                PageTitel = "学生详情页面Detail"
            };

            return View(homeDetailViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
