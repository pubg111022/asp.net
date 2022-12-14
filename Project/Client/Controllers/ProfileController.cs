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

namespace Client.Controllers
{
    public class ProfileController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public ProfileController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            try
            {
                User userSession = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                if (userSession == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.user = userSession;
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Profile/Details/5
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

        // GET: Profile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
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

        // GET: Profile/Edit/5
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

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Phone,Username,Password,Gender,Role,Image,Status,Birthday,Created_Date")] User user, List<IFormFile> files)
        {
            try
            {
                User userSession = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                user.Image = userSession.Image;
                user.Email = userSession.Email;
                user.Password = userSession.Password;
                user.Birthday = userSession.Birthday;
                user.Created_Date = userSession.Created_Date;
            }
            catch (Exception)
            {

            }
            if (id != user.Id)
            {
                return NotFound();
            }
            var filePaths = new List<string>();
            if (files.Count != 0)
            {
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
                            user.Image = formFile.FileName;
                        }
                    }
                }
            }
            
           
                try
                {
                    _context.Update(user);
                    string json = JsonConvert.SerializeObject(user);
                    HttpContext.Session.SetString("user", json);
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

        // GET: Profile/Delete/5
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

        // POST: Profile/Delete/5
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
