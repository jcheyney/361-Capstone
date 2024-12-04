using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly List<Customer> _customers;

        public CustomerController()
        {
            // Example in-memory list; replace with a database context for production
            _customers = new List<Customer>
            {
                new Customer
                {
                    customerID = 1,
                    userName = "JohnDoe",
                    userID = 101,
                    paymentID = 201
                }
            };
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.customerID == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer newCustomer)
        {
            if (newCustomer == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            newCustomer.customerID = _customers.Count + 1;
            _customers.Add(newCustomer);

            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.customerID }, newCustomer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = _customers.FirstOrDefault(c => c.customerID == id);

            if (customer == null)
            {
                return NotFound();
            }
