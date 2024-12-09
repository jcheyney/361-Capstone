using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Tests
{
    public class CategoryControllerTests
    {
        private CategoryController GetController()
        {
            return new CategoryController();
        }

        [Fact]
        public void GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = controller.GetCategories();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var categories = Assert.IsType<List<Category>>(okResult.Value);
            Assert.Single(categories); // Expecting one initial category
            Assert.Equal("Electronics", categories.First().categoryName);
        }

        [Fact]
        public void GetCategory_ShouldReturnCategory_WhenExists()
        {
            // Arrange
            var controller = GetController();
            var testId = 1;

            // Act
            var result = controller.GetCategory(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var category = Assert.IsType<Category>(okResult.Value);
            Assert.Equal(testId, category.categoryID);
        }

        [Fact]
        public void GetCategory_ShouldReturnNotFound_WhenDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var nonExistingId = 999;

            // Act
            var result = controller.GetCategory(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateCategory_ShouldAddCategory()
        {
            // Arrange
            var controller = GetController();
            var newCategory = new Category
            {
                categoryName = "Books"
            };

            // Act
            var result = controller.CreateCategory(newCategory);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var category = Assert.IsType<Category>(createdAtActionResult.Value);
            Assert.Equal(2, category.categoryID); // Expecting ID increment
            Assert.Equal("Books", category.categoryName);
        }

        [Fact]
        public void CreateCategory_ShouldReturnBadRequest_WhenInvalid()
        {
            // Arrange
            var controller = GetController();
            var invalidCategory = new Category(); // Missing required fields

            // Act
            var result = controller.CreateCategory(invalidCategory);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void UpdateCategory_ShouldModifyExistingCategory()
        {
            // Arrange
            var controller = GetController();
            var updatedCategory = new Category
            {
                categoryName = "Updated Electronics"
            };

            // Act
            var result = controller.UpdateCategory(1, updatedCategory);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify update
            var category = controller.GetCategory(1).Result.Value;
            Assert.Equal("Updated Electronics", category.categoryName);
        }

        [Fact]
        public void UpdateCategory_ShouldReturnNotFound_WhenCategoryDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var updatedCategory = new Category
            {
                categoryName = "Non-existent"
            };

            // Act
            var result = controller.UpdateCategory(999, updatedCategory);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateCategory_ShouldReturnBadRequest_WhenInvalid()
        {
            // Arrange
            var controller = GetController();
            var invalidCategory = new Category(); // Missing required fields

            // Act
            var result = controller.UpdateCategory(1, invalidCategory);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeleteCategory_ShouldRemoveCategory()
        {
            // Arrange
            var controller = GetController();
            var testId = 1;

            // Act
            var result = controller.DeleteCategory(testId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify removal
            var getResult = controller.GetCategory(testId);
            Assert.IsType<NotFoundResult>(getResult.Result);
        }

        [Fact]
        public void DeleteCategory_ShouldReturnNotFound_WhenDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var nonExistingId = 999;

            // Act
            var result = controller.DeleteCategory(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
