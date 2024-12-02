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
        private static List<Guest> guests = new List<Guest>
        {
            new Guest { guestID = 1, paymentID = 1001 },
            new Guest { guestID = 2, paymentID = 1002 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Guest>> GetGuests()
        {
            return Ok(guests);
        }

        [HttpGet("{guestID}")]
        public ActionResult<Guest> GetGuest(int guestID)
        {
            var guest = guests.FirstOrDefault(g => g.guestID == guestID);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpPost]
        public ActionResult<Guest> CreateGuest([FromBody] Guest newGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            guests.Add(newGuest);
            return CreatedAtAction(nameof(GetGuest), new { guestID = newGuest.guestID }, newGuest);
        }

        [HttpPut("{guestID}")]
        public ActionResult UpdateGuest(int guestID, [FromBody] Guest updatedGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGuest = guests.FirstOrDefault(g => g.guestID == guestID);
            if (existingGuest == null)
            {
                return NotFound();
            }

            existingGuest.paymentID = updatedGuest.paymentID;

            return NoContent();
        }

        [HttpDelete("{guestID}")]
        public ActionResult DeleteGuest(int guestID)
        {
            var guest = guests.FirstOrDefault(g => g.guestID == guestID);
            if (guest == null)
            {
                return NotFound();
            }

            guests.Remove(guest);
            return NoContent();
        }
    }
}
