using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;

namespace WesthoughtonWorldOfWicker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Westhoughton World Of Wicker";

            return View();
        }

        [HttpPost]
        public IActionResult SubmitContactForm()
        {
            Contact model = new Contact();
            model.Date = DateTime.Now;
            model.Name = HttpContext.Request.Form["name"];
            model.Email = HttpContext.Request.Form["email"];
            model.Topic = HttpContext.Request.Form["topic"];
            model.Message = HttpContext.Request.Form["message"];

            _context.Contact.Add(model);
            _context.SaveChanges();

            return Redirect("Contact");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View("~/Views/Shared/AccessDenied.cshtml");
        }
    }
}
