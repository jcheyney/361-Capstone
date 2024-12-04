using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses

public partial class{ 
    public int userAddressID{get; set;}

    public string country{get; set;}

    public string userState {get; set;}

    public string street {get; set;}

    public string city {get; set;}

    public string zipcode {get; set;}

}