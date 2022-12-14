using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class JobsController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public JobsController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public IActionResult Index()
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                List<Company> companies = _context.Companies.ToList();
                List<Job_Category> categories = _context.Job_Categories.ToList();
                if (user.Role != 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.user = user;
                ViewBag.companies = companies;
                ViewBag.categories = categories;
            }
            catch (Exception)
            {

                return RedirectToAction("index", "Home");
            }
           
            return View();
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Index([Bind("Id,Title,Location,Department,Quantity,Skill_Level,Description,Offer_Salary,ExpirationDate,Status,Created_Date,Category_Id,User_Id,Company_Id")] Job job)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            Guid id = Guid.NewGuid();
            job.Id = id.ToString();
            job.Created_Date = DateTime.Now;
            job.Status = false;
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            List<Company> companies = _context.Companies.ToList();
            List<Job_Category> categories = _context.Job_Categories.ToList();
            ViewBag.user = user;
            ViewBag.companies = companies;
            ViewBag.categories = categories;
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Location,Department,Quantity,Skill_Level,Description,Offer_Salary,ExpirationDate,Status,Created_Date,Category_Id,User_Id,Company_Id")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
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
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var job = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(string id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
