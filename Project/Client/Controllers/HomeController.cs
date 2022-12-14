using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using Microsoft.AspNetCore.Http;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecruitmentManagementContext _context;

        public HomeController(RecruitmentManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index(string category,string name)
        {
            if (name != null)
            {
                if (category != null)
                {
                    List<Job> jobs = _context.Jobs.Where(x =>  x.Category_Id == category && x.Title.Contains(name)).ToList();
                    ViewBag.jobs = jobs;
                }
                else
                {
                    List<Job> jobs = _context.Jobs.ToList();
                    ViewBag.jobs = jobs;
                }
            }
            else
            {
                List<Job> jobs = _context.Jobs.ToList();
                ViewBag.jobs = jobs;
            }
          
           
            List<Job_Category> categories = _context.Job_Categories.ToList();
            ViewBag.categories = categories;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
