using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApp.Controllers.Interfaces;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase, ICartController
    {
        private readonly AppDbContext _context;

        public CartItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CartItems> GetCartItems()
        {
            return _context.CartItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CartItems> GetCartItem(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult CreateCartItem(CartItems cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartID }, cartItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(int id, CartItems cartItem)
        {
            if (id != cartItem.CartID)
            {
                return BadRequest();
            }

            var existingItem = _context.CartItems.Find(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _context.Entry(existingItem).CurrentValues.SetValues(cartItem);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            var item = _context.CartItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
