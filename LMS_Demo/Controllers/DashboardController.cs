using LMS_Demo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LMS_Demo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult StudentDashbord()
        {
            ViewBag.userid = _userManager.GetUserName(HttpContext.User);
          
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
