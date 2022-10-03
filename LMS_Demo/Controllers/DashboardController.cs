using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LMS_Demo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult StudentDashbord()
        {
           
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
        public IActionResult FacilitatorDashbord()
        {
            return View();

        }
        public IActionResult HODDashbord()
        {
            return View();

        }
        public IActionResult AdminDashbord()
        {
            return View();

        }
        public IActionResult SponsorDashbord()
        {
            return View();

        }
    }
}
