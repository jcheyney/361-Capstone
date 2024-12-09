using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DatabaseApp.Controllers;

namespace DatabaseApp.Tests
{
    public class CustomerControllerTests
    {
        private CustomerController GetController()
        {
            return new CustomerController();
        }

        [Fact]
        public void GetCustomers_ShouldReturnAllCustomers()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = controller.GetCustomers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var customers = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Single(customers);
            Assert.Equal("JohnDoe", customers.First().userName);
        }

        [Fact]
        public void GetCustomer_ShouldReturnCustomer_WhenExists()
        {
            // Arrange
            var controller = GetController();
            var testId = 1;

            // Act
            var result = controller.GetCustomer(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var customer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal(testId, customer.customerID);
        }

        [Fact]
        public void GetCustomer_ShouldReturnNotFound_WhenDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var nonExistingId = 999;

            // Act
            var result = controller.GetCustomer(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateCustomer_ShouldAddCustomer()
        {
            // Arrange
            var controller = GetController();
            var newCustomer = new Customer
            {
                userName = "JaneDoe",
                userID = 102,
                paymentID = 202
            };

            // Act
            var result = controller.CreateCustomer(newCustomer);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var customer = Assert.IsType<Customer>(createdAtActionResult.Value);
            Assert.Equal(2, customer.customerID);
            Assert.Equal("JaneDoe", customer.userName);
        }

        [Fact]
        public void CreateCustomer_ShouldReturnBadRequest_WhenInvalid()
        {
            // Arrange
            var controller = GetController();
            var invalidCustomer = new Customer(); // Missing required fields

            // Act
            var result = controller.CreateCustomer(invalidCustomer);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void UpdateCustomer_ShouldModifyExistingCustomer()
        {
            // Arrange
            var controller = GetController();
            var updatedCustomer = new Customer
            {
                userName = "UpdatedJohn",
                userID = 103,
                paymentID = 203
            };

            // Act
            var result = controller.UpdateCustomer(1, updatedCustomer);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify update
            var customer = controller.GetCustomer(1).Result.Value;
            Assert.Equal("UpdatedJohn", customer.userName);
        }

        [Fact]
        public void UpdateCustomer_ShouldReturnNotFound_WhenDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var updatedCustomer = new Customer
            {
                userName = "NonExistent"
            };

            // Act
            var result = controller.UpdateCustomer(999, updatedCustomer);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteCustomer_ShouldRemoveCustomer()
        {
            // Arrange
            var controller = GetController();
            var testId = 1;

            // Act
            var result = controller.DeleteCustomer(testId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify removal
            var getResult = controller.GetCustomer(testId);
            Assert.IsType<NotFoundResult>(getResult.Result);
        }

        [Fact]
        public void DeleteCustomer_ShouldReturnNotFound_WhenDoesNotExist()
        {
            // Arrange
            var controller = GetController();
            var nonExistingId = 999;

            // Act
            var result = controller.DeleteCustomer(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
