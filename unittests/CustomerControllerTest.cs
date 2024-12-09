using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;

namespace DatabaseApp.Tests
{
    public class CustomerControllerTest
    {
        private CustomerController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedCustomers(context);
            return new CustomerController(context);
        }

        private void SeedCustomers(AppDbContext context)
        {
            context.Customers.AddRange(new List<Customer>
            {
                new Customer { CustomerID = 1, UserName = "JohnDoe", UserID = 101, PaymentID = 201 },
                new Customer { CustomerID = 2, UserName = "JaneDoe", UserID = 102, PaymentID = 202 }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetCustomers_ShouldReturnAllCustomers()
        {
            var controller = GetController();

            var result = controller.GetCustomers().Value.ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetCustomer_ValidId_ShouldReturnCustomer()
        {
            var controller = GetController();

            var result = controller.GetCustomer(1).Value;

            Assert.NotNull(result);
            Assert.Equal("JohnDoe", result.UserName);
        }

        [Fact]
        public void GetCustomer_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetCustomer(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
