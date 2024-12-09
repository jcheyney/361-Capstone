using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Tests
{
    public class UserAddressControllerTests
    {
        private readonly UserAddressController _controller;

        public UserAddressControllerTests()
        {
            _controller = new UserAddressController();
        }

        [Fact]
        public void GetUserAddresses_ShouldReturnAllUserAddresses()
        {
            // Act
            var result = _controller.GetUserAddresses() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var addresses = Assert.IsAssignableFrom<IEnumerable<UserAddress>>(result.Value);
            Assert.NotEmpty(addresses);
        }

        [Fact]
        public void GetUserAddress_ValidId_ShouldReturnUserAddress()
        {
            // Act
            var result = _controller.GetUserAddress(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var address = Assert.IsType<UserAddress>(result.Value);
            Assert.Equal(1, address.userAddressID);
        }

        [Fact]
        public void GetUserAddress_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.GetUserAddress(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateUserAddress_ValidUserAddress_ShouldReturnCreatedAddress()
        {
            // Arrange
            var newUserAddress = new UserAddress
            {
                country = "Canada",
                userState = "ON",
                street = "456 Maple Ave",
                city = "Toronto",
                zipcode = "M4B1B4"
            };

            // Act
            var result = _controller.CreateUserAddress(newUserAddress) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            var createdAddress = Assert.IsType<UserAddress>(result.Value);
            Assert.Equal(2, createdAddress.userAddressID); // Assuming this is the second address
        }

        [Fact]
        public void CreateUserAddress_NullUserAddress_ShouldReturnBadRequest()
        {
            // Act
            var result = _controller.CreateUserAddress(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void CreateUserAddress_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidUserAddress = new UserAddress();
            _controller.ModelState.AddModelError("street", "Required");

            // Act
            var result = _controller.CreateUserAddress(invalidUserAddress);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
