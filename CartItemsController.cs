using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store_App.Controllers.Interfaces;
using Store_App.Helpers;
using Store_App.Models.DBClasses;
using System.Data;

namespace DatabaseApp.Controller {
    [Route("[controller]/[action]")]
    [ApiController]
    public class CartItemsController : ControllerBase, ICartController
    {
        private readonly AppDbContext _context;

        public CartItemsController(AppDbContext context)
        {
             _context = context;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItems>>> GetCartItems()
        {
             try
         {
                var items = await _context.CartItems.ToListAsync();
              return Ok(items);
          }   
          catch (Exception ex)
          {
             return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
         }
        }

        private static List<CartItems> cartItems = new List<CartItems>
        {
            new CartItems { cartID = 1, itemID = 101, itemCount = 2, itemPrice = 20 },
            new CartItems { cartID = 2, itemID = 102, itemCount = 1, itemPrice = 15 }
        };

        // GET: api/CartItems
        [HttpGet]
        public ActionResult<IEnumerable<CartItems>> GetCartItems()
        {
            return Ok(cartItems);
        }

        // GET: api/CartItems/5
        [HttpGet("{cartID}")]
        public ActionResult<CartItems> GetCartItem(int cartID)
        {
            var item = cartItems.FirstOrDefault(ci => ci.cartID == cartID);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/CartItems
        [HttpPost]
        public ActionResult<CartItems> CreateCartItem([FromBody] CartItems newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cartItems.Add(newItem);
            return CreatedAtAction(nameof(GetCartItem), new { cartID = newItem.cartID }, newItem);
        }

        // PUT: api/CartItems/5
        [HttpPut("{cartID}")]
        public ActionResult UpdateCartItem(int cartID, [FromBody] CartItems updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingItem = cartItems.FirstOrDefault(ci => ci.cartID == cartID);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.itemID = updatedItem.itemID;
            existingItem.itemCount = updatedItem.itemCount;
            existingItem.itemPrice = updatedItem.itemPrice;

            return NoContent();
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{cartID}")]
        public ActionResult DeleteCartItem(int cartID)
        {
            var item = cartItems.FirstOrDefault(ci => ci.cartID == cartID);
            if (item == null)
            {
                return NotFound();
            }

            cartItems.Remove(item);
            return NoContent();
        }
    }
}