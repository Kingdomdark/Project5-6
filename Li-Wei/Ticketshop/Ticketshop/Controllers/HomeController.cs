﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketshop.Data;
using Ticketshop.Models;
using Ticketshop.ViewModel;

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
            var result = _context.Tickets.Select(s => s).ToList() ;

            return View(result);

        }

        public IActionResult Events()
        {
            ViewData["Message"] = "This is your events page";

            var result = _context.Tickets.Select(s => s).ToList();
            //var innerjoin = from T in _context.Tickets
            //                join E in _context.Theaters
            //                     on T.TheaterID equals E.TheaterID into tgroup
            //                select new
            //                {
            //                    eventname = T.Eventname,
            //                    genre = T.Genre,
            //                    price = T.Price,
            //                    time = T.DateTime,
            //                    theater = tgroup.Theat
            //                };

            var join = from ticket in _context.Tickets
                       from theater in _context.Theaters
                       where ticket.TicketID == theater.TheaterID
                       select new
                       {
                           eventname = ticket.Eventname,
                           genre = ticket.Genre,
                           price = ticket.Price,
                           time = ticket.DateTime,
                           availableseats = theater.Available_seats,
                           theateradress = theater.Theateradress,
                           theatername = theater.Theatername
                       };
            EventViewModel eV = new EventViewModel
            {
                TicketInfo = join
            };

            foreach(var ee in eV.TicketInfo)
            {
                var apple = ee;
            }
            return View(eV);
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
            return View();
        }
    }
}
