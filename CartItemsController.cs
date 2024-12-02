using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private static List<CartItems> cartItems = new List<CartItems>
        {
            new CartItems { cartID = 1, itemID = 101, itemCount = 2, itemPrice = 20 },
            new CartItems { cartID = 2, itemID = 102, itemCount = 1, itemPrice = 15 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<CartItems>> GetCartItems()
        {
            return Ok(cartItems);
        }

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
