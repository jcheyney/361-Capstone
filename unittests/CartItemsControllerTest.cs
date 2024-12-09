using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Tests
{
    public class CartItemsControllerTest
    {
        private List<CartItems> GetTestCartItems()
        {
            return new List<CartItems>
            {
                new CartItems { CartID = 1, ItemID = 101, ItemCount = 2, ItemPrice = 200 },
                new CartItems { CartID = 2, ItemID = 102, ItemCount = 1, ItemPrice = 150 }
            };
        }

        [Fact]
        public void GetCartItems_ShouldReturnAllItems()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);

            var result = controller.GetCartItems();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<CartItems>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetCartItem_ShouldReturnItem_WhenItemExists()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);
            var result = controller.GetCartItem(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<CartItems>(okResult.Value);
            Assert.Equal(1, item.CartID);
        }

        [Fact]
        public void GetCartItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);
            var result = controller.GetCartItem(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateCartItem_ShouldAddItem()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            var controller = new CartItemsController(context);

            var newItem = new CartItems { CartID = 3, ItemID = 103, ItemCount = 3, ItemPrice = 300 };
            var result = controller.CreateCartItem(newItem);

            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
            var item = Assert.IsType<CartItems>(createdAtResult.Value);
            Assert.Equal(3, item.CartID);
        }

        [Fact]
        public void UpdateCartItem_ShouldModifyExistingItem()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);

            var updatedItem = new CartItems { CartID = 1, ItemID = 201, ItemCount = 5, ItemPrice = 500 };
            var result = controller.UpdateCartItem(1, updatedItem);

            Assert.IsType<NoContentResult>(result);

            var updated = context.CartItems.Find(1);
            Assert.Equal(5, updated.ItemCount);
            Assert.Equal(500, updated.ItemPrice);
        }

        [Fact]
        public void DeleteCartItem_ShouldRemoveItem()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);

            var result = controller.DeleteCartItem(1);

            Assert.IsType<NoContentResult>(result);
            Assert.Null(context.CartItems.Find(1));
        }

        [Fact]
        public void DeleteCartItem_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new AppDbContext(options);
            context.CartItems.AddRange(GetTestCartItems());
            context.SaveChanges();

            var controller = new CartItemsController(context);

            var result = controller.DeleteCartItem(999);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
