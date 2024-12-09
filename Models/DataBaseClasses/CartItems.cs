using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class CartItems
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public int ItemPrice { get; set; }
    }
}
