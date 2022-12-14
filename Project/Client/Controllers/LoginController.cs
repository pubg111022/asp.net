using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;
using Newtonsoft.Json;
using NToastNotify;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IToastNotification _toastNotification;

        public LoginController(RecruitmentManagementContext context, IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
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

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user)
        {
            if(user.Email == null || user.Password == null)
            {
                ViewBag.error = "Enter username and password!";
                return RedirectToAction("Index");
            }
            var users = await _context.Users
                .Where(x=>x.Email.Equals(user.Email)).FirstOrDefaultAsync();
           
            var checkPassword = false;
            try
            {
                checkPassword = Crypto.VerifyHashedPassword(users.Password, user.Password);
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Login Fail!");
                return RedirectToAction("Index", "Home");

            }
            if (users !=null && checkPassword==true)
            {
               
                if(users.Role==0 || users.Role == 1)
                {
                    string json = JsonConvert.SerializeObject(users);
                    HttpContext.Session.SetString("user", json);
                    _toastNotification.AddSuccessToastMessage("Login success!");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                _toastNotification.AddErrorToastMessage("Login Fail!");
                return RedirectToAction("Index");
                }
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Login Fail!");
                return RedirectToAction("Index");
            }
        }

        // GET: Login/Edit/5
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

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
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

        // POST: Login/Delete/5
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
