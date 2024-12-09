using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DatabaseApp.Models.DBClasses;

namespace DatabaseApp.Controllers.Interfaces
{
    public interface IPaymentController
    {
        IEnumerable<Payment> GetPayment();
        ActionResult<Payment> GetPayment(int paymentID); // Correct return type
        IActionResult CreatePayment(Payment newPayment); // Correct return type
        IActionResult UpdatePayment(int paymentID, Payment updatedPayment); // Correct return type
        IActionResult DeletePayment(int paymentID); // Correct return type
    }
}
