using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class Guest
    {
        [Key]
        public int GuestID { get; set; }

        [Required]
        public int PaymentID { get; set; }
    }
}
