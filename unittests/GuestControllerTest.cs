using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Tests
{
    public class GuestControllerTests
    {
        private readonly GuestController _controller;

        public GuestControllerTests()
        {
            // Initialize the GuestController
            _controller = new GuestController();
        }

        [Fact]
        public void GetGuests_ShouldReturnAllGuests()
        {
            // Act
            var result = _controller.GetGuests() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var guests = Assert.IsAssignableFrom<IEnumerable<Guest>>(result.Value);
            Assert.NotEmpty(guests);
        }

        [Fact]
        public void GetGuest_ValidId_ShouldReturnGuest()
        {
            // Arrange
            var validId = 1;

            // Act
            var result = _controller.GetGuest(validId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var guest = Assert.IsType<Guest>(result.Value);
            Assert.Equal(validId, guest.guestID);
        }

        [Fact]
        public void GetGuest_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var invalidId = 999;

            // Act
            var result = _controller.GetGuest(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateGuest_ValidGuest_ShouldReturnCreatedGuest()
        {
            // Arrange
            var newGuest = new Guest { guestID = 3, paymentID = 1003 };

            // Act
            var result = _controller.CreateGuest(newGuest) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            var createdGuest = Assert.IsType<Guest>(result.Value);
            Assert.Equal(newGuest.guestID, createdGuest.guestID);
            Assert.Equal(newGuest.paymentID, createdGuest.paymentID);
        }

        [Fact]
        public void CreateGuest_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("guestID", "Required");
            var newGuest = new Guest { paymentID = 1004 };

            // Act
            var result = _controller.CreateGuest(newGuest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void UpdateGuest_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var validId = 1;
            var updatedGuest = new Guest { guestID = validId, paymentID = 2001 };

            // Act
            var result = _controller.UpdateGuest(validId, updatedGuest);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateGuest_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var invalidId = 999;
            var updatedGuest = new Guest { guestID = invalidId, paymentID = 2002 };

            // Act
            var result = _controller.UpdateGuest(invalidId, updatedGuest);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteGuest_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var validId = 1;

            // Act
            var result = _controller.DeleteGuest(validId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteGuest_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var invalidId = 999;

            // Act
            var result = _controller.DeleteGuest(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
