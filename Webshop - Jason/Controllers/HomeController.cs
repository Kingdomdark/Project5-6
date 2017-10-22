using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketshop.Models;
using Model;

namespace Ticketshop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    [Route ("api/[controller]")]
    public class MoviesController : Controller {
        private readonly TicketContext _context;

        public MoviesController (TicketContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet("Events")]
        public IEnumerable<Theater> Get () 
        {
            return _context.Theaters.ToList ();;
        }
        [HttpGet ("Events/{id}")]
        public IActionResult Get (int id) 
        {
            TicketContext ticketContext = new TicketContext();
            var theater = ticketContext.Theaters.Single(Theater => Theater.TheaterID == id);
            return Ok(theater);
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] Theater value) 
        {

        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] Theater value) 
        {

        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) 
        { 

        }
    }
}
