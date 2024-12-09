using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GuestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Guest>> GetGuests()
        {
            return Ok(_context.Guests.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Guest> GetGuest(int id)
        {
            var guest = _context.Guests.Find(id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPost]
        public IActionResult CreateGuest([FromBody] Guest guest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Guests.Add(guest);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGuest), new { id = guest.GuestID }, guest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuest(int id, [FromBody] Guest updatedGuest)
        {
            var guest = _context.Guests.Find(id);
            if (guest == null) return NotFound();

            _context.Entry(guest).CurrentValues.SetValues(updatedGuest);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var guest = _context.Guests.Find(id);
            if (guest == null) return NotFound();

            _context.Guests.Remove(guest);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
