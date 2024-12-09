using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserAddressController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserAddress>> GetUserAddresses()
        {
            return Ok(_context.UserAddresses.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<UserAddress> GetUserAddress(int id)
        {
            var userAddress = _context.UserAddresses.Find(id);
            if (userAddress == null) return NotFound();
            return Ok(userAddress);
        }

        [HttpPost]
        public IActionResult CreateUserAddress([FromBody] UserAddress userAddress)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.UserAddresses.Add(userAddress);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserAddress), new { id = userAddress.UserAddressID }, userAddress);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserAddress(int id, [FromBody] UserAddress updatedUserAddress)
        {
            var userAddress = _context.UserAddresses.Find(id);
            if (userAddress == null) return NotFound();

            _context.Entry(userAddress).CurrentValues.SetValues(updatedUserAddress);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserAddress(int id)
        {
            var userAddress = _context.UserAddresses.Find(id);
            if (userAddress == null) return NotFound();

            _context.UserAddresses.Remove(userAddress);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
