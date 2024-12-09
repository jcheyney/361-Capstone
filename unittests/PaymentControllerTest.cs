using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DataBaseClasses;

namespace DatabaseApp.Tests
{
    public class PaymentControllerTests
    {
        private readonly PaymentController _controller;

        public PaymentControllerTests()
        {
            _controller = new PaymentController();
        }

        [Fact]
        public void GetPayment_ShouldReturnAllPayments()
        {
            // Act
            var result = _controller.GetPayment() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var payments = Assert.IsAssignableFrom<IEnumerable<Payment>>(result.Value);
            Assert.NotEmpty(payments);
        }

        [Fact]
        public void GetPayment_ValidId_ShouldReturnPayment()
        {
            // Act
            var result = _controller.GetPayment(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var payment = Assert.IsType<Payment>(result.Value);
            Assert.Equal(1, payment.paymentID);
        }

        [Fact]
        public void GetPayment_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.GetPayment(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreatePayment_ValidPayment_ShouldReturnCreatedPayment()
        {
            // Arrange
            var newPayment = new Payment
            {
                cardNumber = "8765432187654321",
                expirationDate = new DateTime(2026, 1, 31),
                cvv = "456",
                addressID = 102,
                customerID = 202
            };

            // Act
            var result = _controller.CreatePayment(newPayment) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            var createdPayment = Assert.IsType<Payment>(result.Value);
            Assert.Equal(2, createdPayment.paymentID); // Assuming second payment
        }

        [Fact]
        public void CreatePayment_NullPayment_ShouldReturnBadRequest()
        {
            // Act
            var result = _controller.CreatePayment(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void CreatePayment_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidPayment = new Payment();
            _controller.ModelState.AddModelError("cardNumber", "Required");

            // Act
            var result = _controller.CreatePayment(invalidPayment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void UpdatePayment_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var updatedPayment = new Payment
            {
                cardNumber = "1111222233334444",
                expirationDate = new DateTime(2025, 5, 31),
                cvv = "789",
                addressID = 103,
                customerID = 203
            };

            // Act
            var result = _controller.UpdatePayment(1, updatedPayment);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdatePayment_InvalidId_ShouldReturnBadRequest()
        {
            // Arrange
            var updatedPayment = new Payment
            {
                paymentID = 999,
                cardNumber = "1111222233334444",
                expirationDate = new DateTime(2025, 5, 31),
                cvv = "789",
                addressID = 103,
                customerID = 203
            };

            // Act
            var result = _controller.UpdatePayment(999, updatedPayment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdatePayment_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var updatedPayment = new Payment();
            _controller.ModelState.AddModelError("cardNumber", "Required");

            // Act
            var result = _controller.UpdatePayment(1, updatedPayment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeletePayment_ValidId_ShouldReturnNoContent()
        {
            // Act
            var result = _controller.DeletePayment(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeletePayment_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.DeletePayment(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
