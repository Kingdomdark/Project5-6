using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketshop.Data;
using Ticketshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Ticketshop.Controllers
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
            var result = _context.Tickets.Select(s => s).ToList();

            return View(result);

        }

        //public IActionResult Events(string searchString)
        //{
        //    var tickets = from ticket in _context.Tickets
        //                  select ticket;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        tickets = tickets.Where(s => s.Eventname.Contains(searchString));
        //    }
        //    return View(tickets);
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "About Us";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Us";

            return View();
        }
        public IActionResult KimiNoNaWa()
        {
            //var KimiNoNaWa = _context.Tickets.Select(s => s.Eventname).ToList();
            var KimiNoNaWa = from ticket in _context.Tickets
                             where ticket.TicketID == 2002
                             select ticket;
            ViewData["Message"] = "Kimi No Na Wa";
            return View(KimiNoNaWa);
        }
    }
}
