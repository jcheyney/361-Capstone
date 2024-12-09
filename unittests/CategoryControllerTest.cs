using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;

namespace DatabaseApp.Tests
{
    public class CategoryControllerTest
    {
        private CategoryController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CategoryTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedCategories(context);
            return new CategoryController(context);
        }

        private void SeedCategories(AppDbContext context)
        {
            context.Categories.AddRange(new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Electronics" },
                new Category { CategoryID = 2, CategoryName = "Books" }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetCategories_ShouldReturnAllCategories()
        {
            var controller = GetController();

            var result = controller.GetCategories().Value.ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetCategory_ValidId_ShouldReturnCategory()
        {
            var controller = GetController();

            var result = controller.GetCategory(1).Value;

            Assert.NotNull(result);
            Assert.Equal("Electronics", result.CategoryName);
        }

        [Fact]
        public void GetCategory_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetCategory(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
