using Microsoft.AspNetCore.Mvc;


namespace WebApp6ByPratik.Controllers
{
    public class HomeController : Controller
    {
        // Using HttpContext
        public IActionResult Index()
        {
            ViewBag.Message = "Hello from HttpContext!";
            return View();
        }

        // Using Session
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("SessionMessage", "Hello from Session!");
            return RedirectToAction("GetSession");
        }

        public IActionResult GetSession()
        {
            ViewBag.SessionMessage = HttpContext.Session.GetString("SessionMessage");
            return View();
        }

        // Using TempData
        public IActionResult SetTempData()
        {
            TempData["TempDataMessage"] = "Hello from TempData!";
            return RedirectToAction("GetTempData");
        }

        public IActionResult GetTempData()
        {
            ViewBag.TempDataMessage = TempData["TempDataMessage"];
            return View();
        }

        // Using Cookies
        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30)
            };
            Response.Cookies.Append("CookieMessage", "Hello from Cookie!", options);
            return RedirectToAction("GetCookie");
        }

        public IActionResult GetCookie()
        {
            ViewBag.CookieMessage = Request.Cookies["CookieMessage"];
            return View();
        }

        // Using Query Strings
        public IActionResult GetQueryString(string message)
        {
            ViewBag.QueryStringMessage = message;
            return View();
        }

        // Using Hidden Fields
        [HttpGet]
        public IActionResult HiddenField()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HiddenField(string hiddenMessage)
        {
            ViewBag.HiddenFieldMessage = hiddenMessage;
            return View();
        }
    }
}
