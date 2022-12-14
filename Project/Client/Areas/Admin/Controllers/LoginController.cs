using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client.Models;
using System.Web.Helpers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using NToastNotify;

namespace Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly RecruitmentManagementContext _context;
        private readonly IToastNotification _toastNotification;
        public LoginController(RecruitmentManagementContext context , IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Admin/Login
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Admin/Login/Details/5
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
        public async Task<IActionResult> Login([Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user)
        {
            var users = await _context.Users
                .Where(x => x.Email.Equals(user.Email)).FirstOrDefaultAsync();
            var checkPassword = false;
            try
            {
                checkPassword = Crypto.VerifyHashedPassword(users.Password, user.Password);
            }
            catch (Exception)
            {
                _toastNotification.AddSuccessToastMessage("Login fail!");
                return RedirectToAction("Index");

            }
            if (users!=null && checkPassword == true)
            {
                if (users.Role == 2)
                {
                    string json = JsonConvert.SerializeObject(users);
                    HttpContext.Session.SetString("user", json);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,users.Id),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Admin");
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    _toastNotification.AddSuccessToastMessage("Login Success!");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _toastNotification.AddSuccessToastMessage("Login fail!");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Login fail!");
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Login/Create
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

        // GET: Admin/Login/Edit/5
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

        // POST: Admin/Login/Edit/5
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

        // GET: Admin/Login/Delete/5
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

        // POST: Admin/Login/Delete/5
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
