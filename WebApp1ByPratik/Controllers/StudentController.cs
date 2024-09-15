using Microsoft.AspNetCore.Mvc;
using WebApp1ByPratik.Models;

namespace WebApp1ByPratik.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyRazorPage()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Student s) 
        {
            if(ModelState.IsValid)
            {
                return View("Details", s);
            }
            else
            {
                return View(s);
            }

        }

        

        public IActionResult Details()
        {
            return View();
        }
    }
}
