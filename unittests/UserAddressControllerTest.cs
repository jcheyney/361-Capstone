using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;

namespace DatabaseApp.Tests
{
    public class UserAddressControllerTest
    {
        private UserAddressController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "UserAddressTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedUserAddresses(context);
            return new UserAddressController(context);
        }

        private void SeedUserAddresses(AppDbContext context)
        {
            context.UserAddresses.AddRange(new List<UserAddress>
            {
                new UserAddress { UserAddressID = 1, Country = "USA", UserState = "CA", Street = "123 Elm St", City = "Los Angeles", ZipCode = "90001" },
                new UserAddress { UserAddressID = 2, Country = "Canada", UserState = "ON", Street = "456 Maple Ave", City = "Toronto", ZipCode = "M4B1B4" }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetUserAddresses_ShouldReturnAllAddresses()
        {
            var controller = GetController();

            var result = controller.GetUserAddresses().Value.ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetUserAddress_ValidId_ShouldReturnAddress()
        {
            var controller = GetController();

            var result = controller.GetUserAddress(1).Value;

            Assert.NotNull(result);
            Assert.Equal("USA", result.Country);
        }

        [Fact]
        public void GetUserAddress_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetUserAddress(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
