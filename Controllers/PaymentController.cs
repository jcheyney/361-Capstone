using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApp.Models.DBClasses;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/payment
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetPayments()
        {
            return Ok(_context.Payments.ToList());
        }

        // GET: api/payment/{id}
        [HttpGet("{id}")]
        public ActionResult<Payment> GetPayment(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }
    }
}
