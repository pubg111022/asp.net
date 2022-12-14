using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
using NToastNotify;

namespace Client.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly IToastNotification _toastNotification;

        private readonly RecruitmentManagementContext _context;

        public ForgotPasswordController(RecruitmentManagementContext context, IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: ForgotPassword
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ForgotPassword/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Forgot([Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user)
        {
            if (user.Email == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var us = _context.Users.Where(x => x.Email.Equals(user.Email)).FirstOrDefault();
                if (us.Email != null)
                {

                EmailModel model = new EmailModel()
                {
                    Subject = "Apply success!",
                    To = user.Email
                };
                using (MailMessage mm = new MailMessage(model.From, model.To))
                {
                    mm.Subject = model.Subject;
                    mm.Body = ForgotPassword(us);
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
                }
                _toastNotification.AddSuccessToastMessage("Chung toi da gui lien ket lay lai mat khau");
                }
            }
            return RedirectToAction("Index","Home");
        }
        public string ForgotPassword(User user)
        {
            Guid id = Guid.NewGuid();
            HttpContext.Session.SetString("changepasswordId", id.ToString());
            HttpContext.Session.SetString("IDAccount", user.Id);

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Views\\Shared\\Mail", "ForgotPassword.cshtml")))
            {
                body = reader.ReadToEnd();
                body = body.Replace("{{link}}", "https://localhost:44305/ChangePassword?id="+id);
            }
            return body;
        }
        // GET: ForgotPassword/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForgotPassword/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: ForgotPassword/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: ForgotPassword/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: ForgotPassword/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: ForgotPassword/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
