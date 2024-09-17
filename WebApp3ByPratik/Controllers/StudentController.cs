
using Microsoft.AspNetCore.Mvc;
using WebApp3ByPratik.Repository;
using WebApp3ByPratik.Models;
using Microsoft.Data.SqlClient;

namespace PmcAddCrud.Controllers
{
    public class StudentController : Controller
    {
        StudentRepo repo = new StudentRepo();
        // GET: StudentController
        public ActionResult Index()
        {
            return View(repo.GetAllRecords());
        }

        // GET: StudentController/Details
        public ActionResult Details(int id)
        {
            try
            {
                return View(repo.ViewRecord(id));
            }
            catch (SqlException ex)
            {
                return Content("OOPS!" + ex.Message);

            }
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.InsertRecord(std);
                    return Content("Data has been inserted successfully!");
                }
                catch (SqlException ex)
                {
                    return Content("OOPS!" + ex.Message);
                }
            }
            else
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.ViewRecord(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
