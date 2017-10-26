using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using lesson3.Models;
using Microsoft.AspNetCore.Mvc;
using restserver.Paginator;
using ExtensionMethods;

namespace lesson3.Controllers {

    [Route ("api/[controller]")]
    public class MoviesController : Controller {
        private readonly MovieContext _context;

        public MoviesController (MovieContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Movie> Get () {
            return _context.Movies.ToList ();;
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            var movie = _context.Movies.FirstOrDefault (t => t.Id == id);
            if (movie == null) {
                return NotFound ();
            }
            return new ObjectResult (movie);
        }
        [HttpGet("GetActorsPaged/{page_index}/{page_size}")]
        public IActionResult GetAllActors(int page_index, int page_size){
            var res = _context.Actors.GetPage<Actor>(page_index, page_size, a => a.Id);
            if (res == null) return NotFound();
            return Ok(res);
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] Movie value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] Movie value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}