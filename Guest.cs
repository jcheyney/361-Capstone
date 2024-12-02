using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class Guest
    {
        [Required]
        public int guestID { get; set; }
        public int paymentID { get; set; }
    }
}
