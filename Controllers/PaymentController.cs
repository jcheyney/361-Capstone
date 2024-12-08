using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly List<Payment> _payments;

        public PaymentController()
        {
            // Example in-memory list; replace with a database context for production
            _payments = new List<Payment>
            {
                new Payment
                {
                    paymentID = 1,
                    cardNumber = "1234567812345678",
                    expirationDate = new DateTime(2025, 12, 31),
                    cvv = "123",
                    addressID = 101,
                    customerID = 201
                }
            };
        }

        // GET: api/Payment
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetPayments()
        {
            return Ok(_payments);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public ActionResult<Payment> GetPayment(int id)
        {
            var payment = _payments.FirstOrDefault(p => p.paymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        public ActionResult<Payment> CreatePayment([FromBody] Payment newPayment)
        {
            if (newPayment == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            newPayment.paymentID = _payments.Count + 1;
            _payments.Add(newPayment);

            return CreatedAtAction(nameof(GetPayment), new { id = newPayment.paymentID }, newPayment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, [FromBody] Payment updatedPayment)
        {
            var payment = _payments.FirstOrDefault(p => p.paymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            payment.cardNumber = updatedPayment.cardNumber;
            payment.expirationDate = updatedPayment.expirationDate;
            payment.cvv = updatedPayment.cvv;
            payment.addressID = updatedPayment.addressID;
            payment.customerID = updatedPayment.customerID;

            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var payment = _payments.FirstOrDefault(p => p.paymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            _payments.Remove(payment);

            return NoContent();
        }
    }

    // Payment class definition (adjust namespace accordingly)
    public class Payment
    {
        public int paymentID { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 13)]
        public string cardNumber { get; set; }

        [Required]
        public DateTime expirationDate { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 3)]
        public string cvv { get; set; }

        public int addressID { get; set; }
        public int customerID { get; set; }
    }
}
