using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Tests
{
    public class ItemsControllerTests
    {
        private readonly ItemsController _controller;

        public ItemsControllerTests()
        {
            // Initialize the ItemsController
            _controller = new ItemsController();
        }

        [Fact]
        public void GetItems_ShouldReturnAllItems()
        {
            // Act
            var result = _controller.GetItems() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var items = Assert.IsAssignableFrom<IEnumerable<Item>>(result.Value);
        }

        [Fact]
        public void GetItem_ValidId_ShouldReturnItem()
        {
            // Arrange
            var newItem = new Item { itemID = 1, itemDescription = "Test Item" };
            _controller.CreateItem(newItem);

            // Act
            var result = _controller.GetItem(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var item = Assert.IsType<Item>(result.Value);
            Assert.Equal(1, item.itemID);
            Assert.Equal("Test Item", item.itemDescription);
        }

        [Fact]
        public void GetItem_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.GetItem(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateItem_ValidItem_ShouldReturnCreatedItem()
        {
            // Arrange
            var newItem = new Item
            {
                itemDescription = "New Item",
                quantity = 10
            };

            // Act
            var result = _controller.CreateItem(newItem) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            var createdItem = Assert.IsType<Item>(result.Value);
            Assert.Equal(1, createdItem.itemID); // First item created
            Assert.Equal("New Item", createdItem.itemDescription);
        }

        [Fact]
        public void CreateItem_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("itemDescription", "Required");
            var newItem = new Item();

            // Act
            var result = _controller.CreateItem(newItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void UpdateItem_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var newItem = new Item { itemID = 1, itemDescription = "Test Item" };
            _controller.CreateItem(newItem);

            var updatedItem = new Item
            {
                itemID = 1,
                itemDescription = "Updated Item",
                quantity = 5
            };

            // Act
            var result = _controller.UpdateItem(1, updatedItem);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateItem_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var updatedItem = new Item { itemID = 999, itemDescription = "Nonexistent Item" };

            // Act
            var result = _controller.UpdateItem(999, updatedItem);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateItem_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var newItem = new Item { itemID = 1, itemDescription = "Test Item" };
            _controller.CreateItem(newItem);

            _controller.ModelState.AddModelError("itemDescription", "Required");
            var updatedItem = new Item();

            // Act
            var result = _controller.UpdateItem(1, updatedItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteItem_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var newItem = new Item { itemID = 1, itemDescription = "Test Item" };
            _controller.CreateItem(newItem);

            // Act
            var result = _controller.DeleteItem(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteItem_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.DeleteItem(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
