using System.Collections.Generic;
using DatabaseApp.Models.DBClasses;

namespace Store_App.Controllers.Interfaces
{
    public interface IPaymentController{
        IEnumerable<Payment> GetPayment();
        Payment GetPayment(int paymentID);
        Payment CreatePayment(Payment newPayment);
        void UpdatePayment(int paymentID, Payment updatedPayment);
        void DeletePayment(int paymentID);
    }
}