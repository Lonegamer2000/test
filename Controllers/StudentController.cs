using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var studentInfo = _context.Students.ToList();
            return View(studentInfo);
        }
        public IActionResult Add()
        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.id == id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.id == student.id);

            if (studentinfo != null)
            {
                studentinfo.FullName = student.FullName;
                studentinfo.PhoneNumber = student.PhoneNumber;
                studentinfo.Email = student.Email;
                studentinfo.RollNo = student.RollNo;

                _context.Update(studentinfo);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.id == id);
            return View(student);
        }

        public IActionResult Remove(Student student)
        {

            var studentToDelete = _context.Students.FirstOrDefault(x => x.id == student.id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            Student student = new Student();

            if (id > 0)
            {
                student = _context.Students.FirstOrDefault(x => x.id == id);
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult AddEdit(Student student)
        {
            if (student.id == 0)
            {
                _context.Add(student);
                _context.SaveChanges();

            }
            else
            {
                var studentinfo = _context.Students.FirstOrDefault(x => x.id == student.id);

                if (studentinfo != null)
                {
                    studentinfo.FullName = student.FullName;
                    studentinfo.PhoneNumber = student.PhoneNumber;
                    studentinfo.Email = student.Email;
                    studentinfo.RollNo = student.RollNo;

                    _context.Update(studentinfo);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}