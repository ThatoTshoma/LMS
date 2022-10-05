using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace LMS_Demo.Controllers
{
    public class AssesmentAttachmentsController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AssesmentAttachmentsController(ApplicationDBContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: AssesmentAttachments
        public async Task<IActionResult> Index()
        {
            var relationshipsContext = _db.AssesmentAttachments.Include(a => a.Faculty).Include(a => a.Module).Include(a => a.Section).Include(a => a.Year);
            return View(await relationshipsContext.ToListAsync());
        }
        public async Task<IActionResult> AllAssesments()
        {
            var relationshipsContext = _db.AssesmentAttachments.Include(a => a.Faculty).Include(a => a.Module).Include(a => a.Section).Include(a => a.Year);
            return View(await relationshipsContext.ToListAsync());
        }

        // GET: AssesmentAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesmentAttachments = await _db.AssesmentAttachments
                .Include(a => a.Faculty)
                .Include(a => a.Module)
                .Include(a => a.Section)
                .Include(a => a.Year)
                .FirstOrDefaultAsync(m => m.AttachID == id);
            if (assesmentAttachments == null)
            {
                return NotFound();
            }

            return View(assesmentAttachments);
        }

        // GET: AssesmentAttachments/Create
        public IActionResult Create()
        {
            ViewData["FacultyID"] = new SelectList(_db.Faculties, "FacultyID", "FacultyName");
            ViewData["ModuleID"] = new SelectList(_db.Modules, "ModuleID", "ModuleName");
            ViewData["SectionID"] = new SelectList(_db.Sections, "SectionID", "SectionName");
            ViewData["YearID"] = new SelectList(_db.Years, "YearID", "YearName");
           // ViewData["TypeID"] = new SelectList(_db.AssesmentType, "TypeID", "TypeName");

            return View();
        }

        // POST: AssesmentAttachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachID,File,TypeID,OpenDate,DueDate,SectionID,FacultyID,ModuleID,YearID,LectureID,Description,TotalMark,Attachment")] AssesmentAttachments assesmentAttachments)
        {
            if (ModelState.IsValid)
            {
                //save File
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(assesmentAttachments.File.FileName);
                string extention = Path.GetExtension(assesmentAttachments.File.FileName);
                assesmentAttachments.Attachment = fileName + DateTime.Now.ToString("yyyy-MM-dd") + extention;
                string path = Path.Combine(wwwRootPath + "/Attachments/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await assesmentAttachments.File.CopyToAsync(fileStream);
                }

                _db.Add(assesmentAttachments);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyID"] = new SelectList(_db.Faculties, "FacultyID", "FacultyID", assesmentAttachments.FacultyID);
            ViewData["ModuleID"] = new SelectList(_db.Modules, "ModuleID", "ModuleID", assesmentAttachments.ModuleID);
            ViewData["SectionID"] = new SelectList(_db.Sections, "SectionID", "SectionID", assesmentAttachments.SectionID);
            ViewData["YearID"] = new SelectList(_db.Years, "YearID", "YearID", assesmentAttachments.YearID);
           // ViewData["TypeID"] = new SelectList(_db.AssesmentType, "TypeID", "TypeID", assesmentAttachments.TypeID);
            return View(assesmentAttachments);
        }
        public FileResult Download(string fileName)
        {
            //var path = $"{this._hostEnvironment.WebRootPath}\\Attachments\\" + fileName;

            var path = Path.Combine(this._hostEnvironment.WebRootPath, "Attachments/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }


        // GET: AssesmentAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesmentAttachments = await _db.AssesmentAttachments.FindAsync(id);
            if (assesmentAttachments == null)
            {
                return NotFound();
            }
            ViewData["FacultyID"] = new SelectList(_db.Faculties, "FacultyID", "FacultyID", assesmentAttachments.FacultyID);
            ViewData["ModuleID"] = new SelectList(_db.Modules, "ModuleID", "ModuleID", assesmentAttachments.ModuleID);
            ViewData["SectionID"] = new SelectList(_db.Sections, "SectionID", "SectionID", assesmentAttachments.SectionID);
            ViewData["YearID"] = new SelectList(_db.Years, "YearID", "YearID", assesmentAttachments.YearID);
            return View(assesmentAttachments);
        }

        // POST: AssesmentAttachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttachID,AttachName,TypeID,OpenDate,DueDate,SectionID,FacultyID,ModuleID,YearID,LectureID,Description,TotalMark,Attachment")] AssesmentAttachments assesmentAttachments)
        {
            if (id != assesmentAttachments.AttachID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(assesmentAttachments);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssesmentAttachmentsExists(assesmentAttachments.AttachID))
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
            ViewData["FacultyID"] = new SelectList(_db.Faculties, "FacultyID", "FacultyID", assesmentAttachments.FacultyID);
            ViewData["ModuleID"] = new SelectList(_db.Modules, "ModuleID", "ModuleID", assesmentAttachments.ModuleID);
            ViewData["SectionID"] = new SelectList(_db.Sections, "SectionID", "SectionID", assesmentAttachments.SectionID);
            ViewData["YearID"] = new SelectList(_db.Years, "YearID", "YearID", assesmentAttachments.YearID);
            return View(assesmentAttachments);
        }

        // GET: AssesmentAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesmentAttachments = await _db.AssesmentAttachments
                .Include(a => a.Faculty)
                .Include(a => a.Module)
                .Include(a => a.Section)
                .Include(a => a.Year)
                .FirstOrDefaultAsync(m => m.AttachID == id);
            if (assesmentAttachments == null)
            {
                return NotFound();
            }

            return View(assesmentAttachments);
        }

        // POST: AssesmentAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assesmentAttachments = await _db.AssesmentAttachments.FindAsync(id);
            _db.AssesmentAttachments.Remove(assesmentAttachments);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssesmentAttachmentsExists(int id)
        {
            return _db.AssesmentAttachments.Any(e => e.AttachID == id);
        }
    }
}
