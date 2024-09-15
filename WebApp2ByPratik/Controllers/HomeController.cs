using Microsoft.AspNetCore.Mvc;
using WebApp2ByPratik.Models;

namespace WebApp2ByPratik.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentServices _studentServices;
        public HomeController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public IActionResult Index()
        {
            //Get student name
            string SName = _studentServices.GetStudentName();

            //Get student list
            var SList = _studentServices.GetStudentList();

            return Content(SName);
        }

       
    }
}
