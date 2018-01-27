using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketshop.Data;
using Ticketshop.Models;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Claims;
using Ticketshop.Models.OrderHistoryViewModels;


namespace Ticketshop.Controllers
{
    public class OrderHistoriesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public OrderHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<IndexViewModel> IndexVMlist = new List<IndexViewModel>();

            var OrderHistoryItems = from OrdHistory in _context.OrderHistories
                                    where OrdHistory.CustomerEmail == id
                                    from eve in _context.Events
                                    where OrdHistory.EventID == eve.EventID
                                    select new
                                    {
                                        Price = eve.Price,
                                        EventID = eve.EventID,
                                        Eventname = eve.Eventname,
                                        Genre = eve.Genre,
                                        DateAndTime = eve.DateAndTime,
                                        Theatername = eve.Theatername,
                                        Theateraddress = eve.Theateradress,
                                        EventType = eve.EventType
                                    };

            foreach (var Event in OrderHistoryItems)
            {
                IndexViewModel objcvm = new IndexViewModel
                {
                    Price = Event.Price,
                    DateAndTime = Event.DateAndTime,
                    EventID = Event.EventID,
                    Eventname = Event.Eventname,
                    Genre = Event.Genre,
                    Theatername = Event.Theatername,
                    Theateradress = Event.Theateraddress,
                    EventType = Event.EventType
                };
                IndexVMlist.Add(objcvm);
            }

            return View(IndexVMlist);
        }
    }
}