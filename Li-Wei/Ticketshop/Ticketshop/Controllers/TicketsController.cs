using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketshop.Data;
using Ticketshop.Models;

namespace Ticketshop.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Tickets
        public IActionResult Index(string searchString)
        {
            //return View(await _context.Tickets.ToListAsync());
            var tickets = from ticket in _context.Tickets
                          select ticket;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Eventname.Contains(searchString));
            }
            return View(tickets);
        }
        public IActionResult Events(string searchString)
        {
            //return View(await _context.Tickets.ToListAsync());
            var tickets = from ticket in _context.Tickets
                          select ticket;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Eventname.Contains(searchString));
            }
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,Price,Eventname,Genre,DateTime")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,Price,Eventname,Genre,DateTime")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketID == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }
    }
}
