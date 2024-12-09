using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [CreditCard]
        [StringLength(16, MinimumLength = 13, ErrorMessage = "Card number must be between 13 and 16 digits.")]
        public string CardNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV must be 3 or 4 digits.")]
        public string CVV { get; set; }

        [Required]
        public int AddressID { get; set; }

        [Required]
        public int CustomerID { get; set; }
    }
}
