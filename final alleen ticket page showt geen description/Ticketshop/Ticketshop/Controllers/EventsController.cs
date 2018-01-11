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

namespace Ticketshop.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index(string searchString)
        {
            var tickets = from ticket in _context.Events
                          select ticket;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Eventname.Contains(searchString));
            }
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> BuyTicket(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }


        [Authorize]
        public async Task<IActionResult> TicketBought(string CustEmail, int id)  //See this when ticket is bought
        {
            OrderHistory order = new OrderHistory()
            {
                CustomerEmail = CustEmail,
                EventID = id
            };

            _context.OrderHistories.Add(order);
            _context.SaveChanges();

            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string email = (from u in _context.ApplicationUser
                            where u.Id == UserId
                            select u.Email).FirstOrDefault();

            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            var query = (from events in _context.Events
                         where events.EventID == id
                         select events);

            foreach (Event events in query)
            {
                events.AvailableTickets = events.AvailableTickets - 1;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TicketShop", "emuricky1997@gmail.com"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Order confirmation";
            message.Body = new TextPart("plain")
            {
                Text = "Thank you for buying " + @event.Eventname.ToString()+ " You can find the detailed information about you ticket on your Order History page" 
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("emuricky1997@gmail.com", "Ticketshop123!");
                client.Send(message);

                client.Disconnect(true);
            }
            return View(@event);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Price,Eventname,Genre,DateAndTime,AvailableTickets,Theatername,Theateradress,EventType,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Price,Eventname,Genre,DateAndTime,AvailableTickets,Theatername,Theateradress,EventType,Description")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
