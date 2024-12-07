using System;
using System.Collections.Generic;

public class Hash_Map
{
    private Dictionary<string, object> myMap = new Dictionary<string, object>();

    public void SetCustomer(string username, string password ,int addressID, int[] cardIDs)
    {

        myMap[username] = new { AddressID = addressID, CardIDs = cardIDs, Password = password, Username = username };
    }

    public void SetProduct(string productName, int itemID, int saleID, int itemWeight, string dimensions, string manufactureInfo, string itemDescription, int rating, int quantity, int photoID)
    {
        myMap[productName] = new
        {
            ItemID = itemID,
            SaleID = saleID,
            ItemWeight = itemWeight,
            Dimensions = dimensions,
            ManufactureInfo = manufactureInfo,
            ItemDescription = itemDescription,
            Rating = rating,
            Quantity = quantity,
            PhotoID = photoID
        };
    }

    public void SetCart(int cartID, int customerID, int totalCost, int orderID)
    {
        string key = "Cart_" + cartID;
        myMap[key] = new { CustomerID = customerID, TotalCost = totalCost, OrderID = orderID };
    }

    public dynamic GetCustomerInfo(string username)
    {
        if (myMap.ContainsKey(username))
        {
            return myMap[username];
        }
        else
        {
            return "Customer not found.";
        }
    }

    public object GetProductInfo(string productName)
    {
        if (myMap.ContainsKey(productName))
        {
            return myMap[productName];
        }
        else
        {
            return "Product not found.";
        }
    }

    public object GetCartInfo(int cartID)
    {
        string key = "Cart_" + cartID;
        if (myMap.ContainsKey(key))
        {
            return myMap[key];
        }
        else
        {
            return "Cart not found.";
        }
    }

    // public static void Main(string[] args)
    // {
    //     Program program = new Program();

    //     program.SetCustomer("Jun", 1824, new int[] {1111});
    //     program.SetCustomer("Armon'e", 1825, new int[] {2222});

    //     program.SetProduct("T-Shirt", 1, 101, 500, "M", "Nike", "Long shirt", 4, 20, 10);
    //     program.SetProduct("Jeans", 2, 102, 1000, "L", "Adidas", "Long Jeans", 5, 15, 20);

    //     program.SetCart(1, 123, 1500, 301);

    //     Console.WriteLine("Customer Info for Jun:");
    //     Console.WriteLine(program.GetCustomerInfo("Jun"));

    //     Console.WriteLine("\nProduct Info for T-Shirt:");
    //     Console.WriteLine(program.GetProductInfo("T-Shirt"));

    //     Console.WriteLine("\nCart Info for Cart ID 1:");
    //     Console.WriteLine(program.GetCartInfo(1));
    // }
}
