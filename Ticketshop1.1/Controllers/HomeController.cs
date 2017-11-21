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
        private TicketContext _context;
        public HomeController(TicketContext context){
            _context = context;
        }
        public IActionResult Index()
        {



            return View();
        }
        [HttpGet]
        public IActionResult Events()
        {
           ViewData["Message"] = "Events page";
           var result =   _context.Tickets.Select( x => x).ToList();
           
            return View(result);
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
