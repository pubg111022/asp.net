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
using System.IO;
using System.Net.Mail;
using System.Net;
using NToastNotify;

namespace Client.Controllers
{
    public class Apply_JobController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IToastNotification _toastNotification;

        public Apply_JobController(RecruitmentManagementContext context , IToastNotification toastNotification )
        {
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Apply_Job
        public async Task<IActionResult> Index(string id)
        {
            var jobs = _context.Jobs.Where(x => x.Id.Equals(id)).FirstOrDefault();
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));

            ViewBag.jobs = jobs;
            ViewBag.user = user;

            return View();
        }

        // GET: Apply_Job/Details/5
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

        // GET: Apply_Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apply_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,User_Id,Job_id,CV,Created_Date")] Apply_Job apply_Job, List<IFormFile> files)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            Guid id = Guid.NewGuid();
            apply_Job.Id = id.ToString();
            apply_Job.Created_Date = DateTime.Now;
            User user = _context.Users.Find(apply_Job.User_Id);
            var filePaths = new List<string>();
            apply_Job.CV = "";
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        apply_Job.CV = formFile.FileName;
                    }
                }
            }
           
                _context.Add(apply_Job);
                await _context.SaveChangesAsync();
                EmailModel model = new EmailModel()
                {
                    Subject = "Apply success!",
                    To = user.Email
                };
            using (MailMessage mm = new MailMessage(model.From, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = Apply(apply_Job);
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(model.From, model.Password);
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;

                    smtp.Send(mm);
                }
                _toastNotification.AddSuccessToastMessage("Chung toi da gui ve email cua ban");
                var jobs = _context.Jobs.Where(x => x.Id.Equals(id)).FirstOrDefault();
                User uss = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));

                ViewBag.jobs = jobs;
                ViewBag.user = uss;
                return RedirectToAction("Index", "Home");
            }
        }
        public string Apply(Apply_Job apply)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Views\\Shared\\Mail", "Apply.cshtml")))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
        // GET: Apply_Job/Edit/5
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

        // POST: Apply_Job/Edit/5
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

        // GET: Apply_Job/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: Apply_Job/Delete/5
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
