using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses
public partial class CartItems{
    [Required]

    public int cartID {get; set;}

    public int itemID {get; set;}

    public int itemCount {get; set;}

    public int itemPrice{get; set;}

}