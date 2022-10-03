using Microsoft.AspNetCore.Mvc;

namespace LMS_Demo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult StudentDashbord()
        {
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
