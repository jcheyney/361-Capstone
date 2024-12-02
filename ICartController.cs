using System.Collections.Generic;
using DatabaseApp.Models.DBClasses;

namespace Store_App.Controllers.Interfaces
{
    public interface ICartController
    {
        IEnumerable<CartItems> GetCartItems();
        CartItems GetCartItem(int cartID);
        CartItems CreateCartItem(CartItems newItem);
        void UpdateCartItem(int cartID, CartItems updatedItem);
        void DeleteCartItem(int cartID);
    }
}
