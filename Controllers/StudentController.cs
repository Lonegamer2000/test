using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context) 
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Student student = new Student();
            var students = new Student();

            return View(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Add(student);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var studentInfo = _context.Students.FirstOrDefault(x => x.id == id);

            return View(studentInfo);
        }



        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var studentInfo = _context.Students.FirstOrDefault(x => x.id == student.id);
            if (studentInfo != null)
            {
                studentInfo.FullName = student.FullName;
                studentInfo.RollNo = student.RollNo;
                studentInfo.Class = student.Class;
                studentInfo.Email= student.Email;
                studentInfo.PhoneNumber = student.PhoneNumber;
                _context.Update(studentInfo);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
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

                studentinfo.FullName = student.FullName;
                studentinfo.RollNo = student.RollNo;
                studentinfo.PhoneNumber = student.PhoneNumber;
                studentinfo.Class = student.Class;

                _context.Update(studentinfo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.id == id);
            _context.Remove(studentinfo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.id == id);
            return View(studentinfo);
        }
    }
}