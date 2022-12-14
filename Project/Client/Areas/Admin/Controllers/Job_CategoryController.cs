using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Job_CategoryController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IToastNotification _toastNotification;
        public Job_CategoryController(RecruitmentManagementContext context, IToastNotification toastrNotification)
        { 
            _context = context;
            _toastNotification = toastrNotification;
        }

        // GET: Admin/Job_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Job_Categories.ToListAsync());
        }

        // GET: Admin/Job_Category/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Category = await _context.Job_Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job_Category == null)
            {
                return NotFound();
            }

            return View(job_Category);
        }

        // GET: Admin/Job_Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Job_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Created_Date")] Job_Category job_Category)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            Guid id = Guid.NewGuid();
            job_Category.Id = id.ToString();
            job_Category.Created_Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(job_Category);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Create success!");
                return RedirectToAction(nameof(Index));
            }
            return View(job_Category);
        }

        // GET: Admin/Job_Category/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Category = await _context.Job_Categories.FindAsync(id);
            if (job_Category == null)
            {
                return NotFound();
            }
            return View(job_Category);
        }

        // POST: Admin/Job_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Status,Created_Date")] Job_Category job_Category)
        {
            if (id != job_Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_Category);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage("Update success!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_CategoryExists(job_Category.Id))
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
            return View(job_Category);
        }

        // GET: Admin/Job_Category/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var job_Category = await _context.Job_Categories.FindAsync(id);
            _context.Job_Categories.Remove(job_Category);
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage("Delete success!");
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Job_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var job_Category = await _context.Job_Categories.FindAsync(id);
            _context.Job_Categories.Remove(job_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_CategoryExists(string id)
        {
            return _context.Job_Categories.Any(e => e.Id == id);
        }
    }
}
