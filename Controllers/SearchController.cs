using InfoTech.Data;
using InfoTech.Models;
using InfoTech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Controllers
{
    public class SearchController : Controller
    {
        private StudentDbContext context;

        public SearchController(StudentDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Student> students;
            List<StudentDetailViewModel> displayStudents = new List<StudentDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                students = context.Students
                   .Include(j => j.Teacher)
                   .ToList();

                foreach (var student in students)
                {
                    List<StudentCourse> studentCourses = context.StudentCourses
                        .Where(js => js.StudentId == student.Id)
                        .Include(js => js.Course)
                        .ToList();

                    StudentDetailViewModel newDisplayStudent = new StudentDetailViewModel(student, studentCourses);
                    displayStudents.Add(newDisplayStudent);
                }
            }
            else
            {
                if (searchType == "teacher")
                {
                    students = context.Students
                        .Include(j => j.Teacher)
                        .Where(j => j.Teacher.Name == searchTerm)
                        .ToList();

                    foreach (Student student in students)
                    {
                        List<StudentCourse> studentCourses = context.StudentCourses
                        .Where(js => js.StudentId == student.Id)
                        .Include(js => js.Course)
                        .ToList();

                        StudentDetailViewModel newDisplayStudent = new StudentDetailViewModel(student, studentCourses);
                        displayStudents.Add(newDisplayStudent);
                    }

                }
                else if (searchType == "course")
                {
                    List<StudentCourse> studentCourses = context.StudentCourses
                        .Where(j => j.Course.Name == searchTerm)
                        .Include(j => j.Student)
                        .ToList();

                    foreach (var student in studentCourses)
                    {
                        Student foundStudent = context.Students
                            .Include(j => j.Teacher)
                            .Single(j => j.Id == student.StudentId);

                        List<StudentCourse> displayCourses = context.StudentCourses
                            .Where(js => js.StudentId == foundStudent.Id)
                            .Include(js => js.Course)
                            .ToList();

                        StudentDetailViewModel newDisplayStudent = new StudentDetailViewModel(foundStudent, displayCourses);
                        displayStudents.Add(newDisplayStudent);
                    }
                }
            }

            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Students with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.students = displayStudents;

            return View("Index");
        }
    }
}
