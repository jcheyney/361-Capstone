using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class Item
    {
        [Key]
        public int ItemID { get; set; }

        public int SalesID { get; set; }

        [Required]
        public int ItemWeight { get; set; }

        [Required]
        [StringLength(200)]
        public string Dimensions { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacture { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageURL { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [Required]
        [Range(0, 5)]
        public float Rating { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemType { get; set; }
    }
}
