using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Tests
{
    public class ItemsControllerTest
    {
        private ItemsController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "ItemsTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedItems(context);
            return new ItemsController(context);
        }

        private void SeedItems(AppDbContext context)
        {
            context.Items.AddRange(new List<Item>
            {
                new Item { ItemID = 1, ItemDescription = "Laptop", Quantity = 10 },
                new Item { ItemID = 2, ItemDescription = "Phone", Quantity = 15 }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetItems_ShouldReturnAllItems()
        {
            var controller = GetController();

            var result = controller.GetItems().Value.ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetItem_ValidId_ShouldReturnItem()
        {
            var controller = GetController();

            var result = controller.GetItem(1).Value;

            Assert.NotNull(result);
            Assert.Equal("Laptop", result.ItemDescription);
        }

        [Fact]
        public void GetItem_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetItem(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
