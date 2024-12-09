using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Tests
{
    public class PaymentControllerTest
    {
        private PaymentController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "PaymentTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedPayments(context);
            return new PaymentController(context);
        }

        private void SeedPayments(AppDbContext context)
        {
            context.Payments.AddRange(new List<Payment>
            {
                new Payment { PaymentID = 1, CardNumber = "1234567812345678", CVV = "123", ExpirationDate = new System.DateTime(2025, 12, 31), AddressID = 101, CustomerID = 201 },
                new Payment { PaymentID = 2, CardNumber = "8765432187654321", CVV = "456", ExpirationDate = new System.DateTime(2026, 11, 30), AddressID = 102, CustomerID = 202 }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetPayments_ShouldReturnAllPayments()
        {
            var controller = GetController();

            var result = controller.GetPayments();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Payment>>>(result);
            var payments = Assert.IsAssignableFrom<IEnumerable<Payment>>(actionResult.Value);

            Assert.NotNull(payments);
            Assert.Equal(2, payments.Count());
        }

        [Fact]
        public void GetPayment_ValidId_ShouldReturnPayment()
        {
            var controller = GetController();

            var result = controller.GetPayment(1);
            var actionResult = Assert.IsType<ActionResult<Payment>>(result);
            var payment = Assert.IsType<Payment>(actionResult.Value);

            Assert.Equal("1234567812345678", payment.CardNumber);
        }

        [Fact]
        public void GetPayment_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetPayment(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
