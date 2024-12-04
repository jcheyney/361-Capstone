using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses

puiblic partial class Payment{
    [Required]
    public int paymentID {get; set;}

    public string cardNumber {get; set;}

    public localDate expirationDate {get; set;}

    public string cvv {get; set;}

    public int addressID {get; set;}

    public int customerID {get; set;}

}