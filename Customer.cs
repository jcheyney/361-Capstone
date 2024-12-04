using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses

public partial class customer{
    public int customerID {get; set;}

    public string userName {get; set;}

    public int userID {get; set;}

    public int paymentID {get; set;}
}