using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketshop.Models;

namespace Ticketshop.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Contact/
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        // GET: /About/
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }




        
        // GET: /Events
        public IActionResult Events()
        {
            ViewData["Message"] = "This is the events page. It shows a table of the events";

            var ticket = new Ticket() {Eventname = "Eventnametest1"};

            return View(ticket);
        }
        // GET: /Error/
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: /Login/
        public IActionResult Login()
        {
            ViewData["Message"] = "This is the login page, where you can log in ofcourse.";

            return View();
        }

        // GET: /Register/
        public IActionResult Register()
        {
            ViewData["Register"] = "This is the register page, where you can create an account ofcourse.";

            return View();
        }
    }
}
