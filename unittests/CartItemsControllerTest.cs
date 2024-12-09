using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Store_App.Models.DBClasses;
using DatabaseApp.Controller;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Store_App.Tests
{
    public class CartItemsControllerTests
    {
        private List<CartItems> GetTestCartItems()
        {
            return new List<CartItems>
            {
                new CartItems { cartID = 1, itemID = 101, itemCount = 2, itemPrice = 20 },
                new CartItems { cartID = 2, itemID = 102, itemCount = 1, itemPrice = 15 }
            };
        }

        [Fact]
        public async Task GetCartItems_ShouldReturnAllItems()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);

            // Act
            var result = await controller.GetCartItems();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CartItems>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var items = Assert.IsType<List<CartItems>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetCartItem_ShouldReturnItem_WhenItemExists()
        {
            // Arrange
            var controller = new CartItemsController(null);
            var testItems = GetTestCartItems();
            var testCartID = 1;

            // Act
            var result = controller.GetCartItem(testCartID);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var item = Assert.IsType<CartItems>(okResult.Value);
            Assert.Equal(testCartID, item.cartID);
        }

        [Fact]
        public void GetCartItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var controller = new CartItemsController(null);
            var testCartID = 999;

            // Act
            var result = controller.GetCartItem(testCartID);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateCartItem_ShouldAddItem()
        {
            // Arrange
            var controller = new CartItemsController(null);
            var newItem = new CartItems { cartID = 3, itemID = 103, itemCount = 1, itemPrice = 25 };

            // Act
            var result = controller.CreateCartItem(newItem);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var item = Assert.IsType<CartItems>(createdAtActionResult.Value);
            Assert.Equal(3, item.cartID);
        }

        [Fact]
        public void UpdateCartItem_ShouldModifyExistingItem()
        {
            // Arrange
            var controller = new CartItemsController(null);
            var updatedItem = new CartItems { cartID = 1, itemID = 201, itemCount = 5, itemPrice = 50 };

            // Act
            var result = controller.UpdateCartItem(1, updatedItem);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateCartItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var controller = new CartItemsController(null);
            var updatedItem = new CartItems { cartID = 999, itemID = 201, itemCount = 5, itemPrice = 50 };

            // Act
            var result = controller.UpdateCartItem(999, updatedItem);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteCartItem_ShouldRemoveItem()
        {
            // Arrange
            var controller = new CartItemsController(null);

            // Act
            var result = controller.DeleteCartItem(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteCartItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var controller = new CartItemsController(null);

            // Act
            var result = controller.DeleteCartItem(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
