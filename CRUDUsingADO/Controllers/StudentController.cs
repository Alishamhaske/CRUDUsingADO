using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL db;
        IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentDAL(this.configuration);
        }


        public IActionResult Index()
        {
            return View(db.GetStudents());
        }

        // GET: StudentController/Details/5
        public IActionResult Details(int id)
        {
            var student = db.GetStudentById(id);
            return View(student);
        }

        // GET: stdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST:stdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {

                int result = db.AddStudent(student);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

            catch
            {
                return View();
            }
        }

        // GET: stdController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.GetStudentById(id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Student student)
        {

            try
            {

                int result = db.UpdateStudent(student);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }

            catch
            {
                return View();
            }
        }

        //delete
        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = db.GetStudentById(id);
            return View();
        }


        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {

                int result = db.DeleteStudent(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }

            catch
            {
                return View();
            }
        }


    }
}
