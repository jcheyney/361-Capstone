using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApp.Controllers.Interfaces;
//using Store_App.Helpers;
using DatabaseApp.Models.DataBaseClasses;

namespace DatabaseApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase, IPaymentController
    {
        private readonly List<Payment> _payments;

        public PaymentController()
        {
            // Example in-memory list; replace with a database context for production
            _payments = new List<Payment>
            {
                new Payment
                // need to use the hashmaps to get this info from the data base 
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
        public ActionResult<IEnumerable<Payment>> GetPayment()
        {
            return Ok(_payments);
        }

        // GET: api/Payment/5
        [HttpGet("{paymentID}")]
        public ActionResult<Payment> GetPayment(int id)
        {
            var payment = _payments.FirstOrDefault(p => p.paymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public ActionResult<Payment> CreatePayment([FromBody] Payment newPayment)
        {
            try
            {
            if (newPayment == null)
            {
                return BadRequest("Payment object is null");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            newPayment.paymentID = _payments.Count + 1;
            _payments.Add(newPayment);

            return CreatedAtAction(nameof(GetPayment), new { id = newPayment.paymentID }, newPayment);
             
            }
        catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, [FromBody] Payment updatedPayment)
        {
            var payment = _payments.FirstOrDefault(p => p.paymentID == id);

            if (payment == null || paymentId != payment.PaymentId)
            {
                return BadRequest("Invalid payment data");
            }
            // if the current payment is null return not found 
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
}
