using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
{
    public partial class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string UserState { get; set; }

        [StringLength(200)]
        public string Street { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }
    }
}
