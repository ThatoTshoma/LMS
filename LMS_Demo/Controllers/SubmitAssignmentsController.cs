using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS_Demo.Controllers
{
    public class SubmitAssignmentsController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;


        public SubmitAssignmentsController(ApplicationDBContext db, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        }

        // GET: SubmitAssignments
        public async Task<IActionResult> Index()
        {
            var relationshipsContext = _db.SubmitAssignment.Include(s => s.Assesment).Include(s => s.Student);
            return View(await relationshipsContext.ToListAsync());
        }

        // GET: SubmitAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitAssignment = await _db.SubmitAssignment
                .Include(s => s.Assesment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SubmitID == id);
            if (submitAssignment == null)
            {
                return NotFound();
            }

            return View(submitAssignment);
        }

        // GET: SubmitAssignments/Create
        public IActionResult Create()
        {
            ViewBag.userid = _userManager.GetUserName(HttpContext.User);
       

            ViewData["AssesmentID"] = new SelectList(_db.Assesments, "AssesmentID", "AssesmentID");
            ViewData["StudentID"] = new SelectList(_db.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: SubmitAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubmitID,StudentID,AssesmentID,File,SubmissionDate")] SubmitAssignment submitAssignment)
        {
            if (ModelState.IsValid)
            {
                //save File
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(submitAssignment.File.FileName);
                string extention = Path.GetExtension(submitAssignment.File.FileName);
                submitAssignment.FilePath = fileName + DateTime.Now.ToString("yyyy-MM-dd") + extention;
                string path = Path.Combine(wwwRootPath + "/Submissions/", fileName);
                String now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                submitAssignment.SubmissionDate = DateTime.Parse(now);
                using (var fileStream = new FileStream(path, FileMode.Create))

                {
                    await submitAssignment.File.CopyToAsync(fileStream);
                }

                _db.Add(submitAssignment);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.userid = _userManager.GetUserName(HttpContext.User);
            ViewData["AssesmentID"] = new SelectList(_db.Assesments, "AssesmentID", "AssesmentID", submitAssignment.AssesmentID);
            ViewData["StudentID"] = new SelectList(_db.Students, "StudentID", "StudentID", submitAssignment.StudentID);
            return View(submitAssignment);
        }

       public FileResult Download(string fileName)
       {
            string path = Path.Combine(this._hostEnvironment.WebRootPath, "Submissions/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
       }



   

        // GET: SubmitAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitAssignment = await _db.SubmitAssignment.FindAsync(id);
            if (submitAssignment == null)
            {
                return NotFound();
            }
            ViewData["AssesmentID"] = new SelectList(_db.Assesments, "AssesmentID", "AssesmentID", submitAssignment.AssesmentID);
            ViewData["StudentID"] = new SelectList(_db.Students, "StudentID", "StudentID", submitAssignment.StudentID);
            return View(submitAssignment);
        }

        // POST: SubmitAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubmitID,StudentID,AssesmentID,FilePath,SubmissionDate")] SubmitAssignment submitAssignment)
        {
            if (id != submitAssignment.SubmitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(submitAssignment);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmitAssignmentExists(submitAssignment.SubmitID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssesmentID"] = new SelectList(_db.Assesments, "AssesmentID", "AssesmentID", submitAssignment.AssesmentID);
            ViewData["StudentID"] = new SelectList(_db.Students, "StudentID", "StudentID", submitAssignment.StudentID);
            return View(submitAssignment);
        }

        // GET: SubmitAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitAssignment = await _db.SubmitAssignment
                .Include(s => s.Assesment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SubmitID == id);
            if (submitAssignment == null)
            {
                return NotFound();
            }

            return View(submitAssignment);
        }

        // POST: SubmitAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submitAssignment = await _db.SubmitAssignment.FindAsync(id);
            _db.SubmitAssignment.Remove(submitAssignment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmitAssignmentExists(int id)
        {
            return _db.SubmitAssignment.Any(e => e.SubmitID == id);
        }
    }
}
