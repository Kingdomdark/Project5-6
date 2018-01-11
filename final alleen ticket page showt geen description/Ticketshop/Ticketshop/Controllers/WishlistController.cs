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
using Ticketshop.Models.WishlistViewModels;

namespace Ticketshop.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wishlists/Index/Emailname
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<IndexViewModel> IndexVMlist = new List<IndexViewModel>();


            //query to add to wishlist.
            var WishlistItems = from wishlst in _context.Wishlists
                                where wishlst.CustomerEmail == id
                                from eve in _context.Events
                                where wishlst.EventID == eve.EventID
                                select new
                                {
                                    EventID = eve.EventID,
                                    Eventname = eve.Eventname,
                                    Genre = eve.Genre,
                                    DateAndTime = eve.DateAndTime,
                                    AvailableTickets = eve.AvailableTickets,
                                    Theatername = eve.Theatername,
                                    Theateraddress = eve.Theateradress,
                                    EventType = eve.EventType
                                };

            //working testquery
            //var tickets = from ticket in _context.Events
            //                select ticket;

            foreach (var Event in WishlistItems)
            {
                IndexViewModel objcvm = new IndexViewModel
                {
                    EventID = Event.EventID,
                    Eventname = Event.Eventname,
                    Genre = Event.Genre,
                    Theatername = Event.Theatername,
                    Theateradress = Event.Theateraddress,
                    EventType = Event.EventType
                };
                IndexVMlist.Add(objcvm);
                Console.WriteLine(objcvm.Eventname);
                Console.WriteLine(objcvm);
            }

            return View(IndexVMlist);
        }



        //Is this even good? :thinking:
        [Authorize]
        public async Task<IActionResult> AddToWishlist(string CustEmail, int id)
        {
            bool Exists = false;

            var CheckExists = from eve in _context.Wishlists
                              where eve.CustomerEmail == CustEmail
                              select eve;

            foreach (Wishlist eve in CheckExists)
            {
                if (eve.EventID == id)
                {
                    Exists = true;
                }
            }
            if (Exists == false)
            {
                Wishlist WishlistItem = new Wishlist
                {
                    CustomerEmail = CustEmail,
                    EventID = id
                };
                _context.Wishlists.Add(WishlistItem);
                _context.SaveChanges();
                //var @event = await _context.Events
                //    .SingleOrDefaultAsync(m => m.EventID == id);
                //if (@event == null)
                //{
                //    return NotFound();
                //}
                var AddedEvent = await _context.Events
                    .SingleOrDefaultAsync(e => e.EventID == id);
                if (AddedEvent == null)
                {
                    return NotFound();
                }
                return View(AddedEvent);
            }
            return View();
        }
        // GET: Wishlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlists
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }
    }
}
