using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; // Add this line
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers.Interfaces
{
    public interface ICartController
    {
        IEnumerable<CartItems> GetCartItems();
        ActionResult<CartItems> GetCartItem(int id); // Correct return type
        IActionResult CreateCartItem(CartItems cartItem); // Correct return type
        IActionResult UpdateCartItem(int id, CartItems cartItem); // Correct return type
        IActionResult DeleteCartItem(int id); // Correct return type
    }
}
