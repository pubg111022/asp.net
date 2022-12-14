using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Client.Controllers
{
    public class ListJobController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public ListJobController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: ListJob
        public async Task<IActionResult> Index()
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                List<Apply_Job> list = _context.Apply_Jobs.Where(x => x.User_Id.Equals(user.Id)).ToList();
                List<Apply_Job> listt = new List<Apply_Job>();
                List<Job> job = _context.Jobs.ToList();
                foreach (var item in list)
                {
                    foreach (var i in job)
                    {
                        if (i.Id.Equals(item.Job_id))
                        {
                            item.Job = i;
                            listt.Add(item);
                        }
                    }
                }
                ViewBag.listJob = listt;
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Login");
            }
          
            return View();
        }

        // GET: ListJob/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_Job = await _context.Apply_Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apply_Job == null)
            {
                return NotFound();
            }

            return View(apply_Job);
        }

        // GET: ListJob/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_Id,Job_id,CV,Created_Date")] Apply_Job apply_Job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apply_Job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apply_Job);
        }

        // GET: ListJob/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_Job = await _context.Apply_Jobs.FindAsync(id);
            if (apply_Job == null)
            {
                return NotFound();
            }
            return View(apply_Job);
        }

        // POST: ListJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,User_Id,Job_id,CV,Created_Date")] Apply_Job apply_Job)
        {
            if (id != apply_Job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apply_Job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Apply_JobExists(apply_Job.Id))
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
            return View(apply_Job);
        }

        // GET: ListJob/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var apply_Job = await _context.Apply_Jobs.FindAsync(id);
            _context.Apply_Jobs.Remove(apply_Job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","ListJob");
        }

        // POST: ListJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var apply_Job = await _context.Apply_Jobs.FindAsync(id);
            _context.Apply_Jobs.Remove(apply_Job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Apply_JobExists(string id)
        {
            return _context.Apply_Jobs.Any(e => e.Id == id);
        }
    }
}
