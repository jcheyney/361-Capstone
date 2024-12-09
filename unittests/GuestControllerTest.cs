using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DatabaseApp.Controllers;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;

namespace DatabaseApp.Tests
{
    public class GuestControllerTest
    {
        private GuestController GetController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "GuestTestDb")
                .Options;

            var context = new AppDbContext(options);
            SeedGuests(context);
            return new GuestController(context);
        }

        private void SeedGuests(AppDbContext context)
        {
            context.Guests.AddRange(new List<Guest>
            {
                new Guest { GuestID = 1, PaymentID = 301 },
                new Guest { GuestID = 2, PaymentID = 302 }
            });
            context.SaveChanges();
        }

        [Fact]
        public void GetGuests_ShouldReturnAllGuests()
        {
            var controller = GetController();

            var result = controller.GetGuests().Value.ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetGuest_ValidId_ShouldReturnGuest()
        {
            var controller = GetController();

            var result = controller.GetGuest(1).Value;

            Assert.NotNull(result);
            Assert.Equal(1, result.GuestID);
        }

        [Fact]
        public void GetGuest_InvalidId_ShouldReturnNotFound()
        {
            var controller = GetController();

            var result = controller.GetGuest(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
