using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly List<UserAddress> _userAddresses;

        public UserAddressController()
        {
            // Example in-memory list; replace with a database context for production
            _userAddresses = new List<UserAddress>
            {
                new UserAddress
                {
                    userAddressID = 1,
                    country = "USA",
                    userState = "NE",
                    street = "123 Main St",
                    city = "Lincoln",
                    zipcode = "68508"
                }
            };
        }

        // GET: api/UserAddress
        [HttpGet]
        public ActionResult<IEnumerable<UserAddress>> GetUserAddresses()
        {
            return Ok(_userAddresses);
        }

        // GET: api/UserAddress/5
        [HttpGet("{id}")]
        public ActionResult<UserAddress> GetUserAddress(int id)
        {
            var userAddress = _userAddresses.FirstOrDefault(ua => ua.userAddressID == id);

            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // POST: api/UserAddress
        [HttpPost]
        public ActionResult<UserAddress> CreateUserAddress([FromBody] UserAddress newUserAddress)
        {
            if (newUserAddress == null || !ModelState.IsValid)
  
