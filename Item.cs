using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Models.DBClasses

public partial class Item{
    public int itemID{get; set;}

    public int salesID{get; set;}

    public int itemWeight{get; set;}

    public string dimensions{get; set;}

    public string manufacture{get; set;}

    public string itemDescription{get; set;}

    public int quantity{get; set;}

    public string imageURL{get; set;}

    public string sku{get; set;}

    public float rating{get; set;}

    public string itemType{get; set;}
}