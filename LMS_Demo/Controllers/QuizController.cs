using LMS_Demo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LMS_Demo.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDBContext _db;
        public QuizController(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Quizzes.ToListAsync());
        }
    }
}
