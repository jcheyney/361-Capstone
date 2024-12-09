using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
    }
}
