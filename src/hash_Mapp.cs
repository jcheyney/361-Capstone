using System;
using System.Collections.Generic;

public class Program
{
    private Dictionary<string, object> myMap = new Dictionary<string, object>();
// string = key ( username, product name, or cart ID)
// values = object 정보 보관소 보관을 자유롭게함 (customers, product, and carts)

    public void SetCustomer(string username, int addressID, int[] cardIDs)
    {

        myMap[username] = new { AddressID = addressID, CardIDs = cardIDs };
    }
//dictionary에다가 고객 정보 보관하는 법
//username이 키가 되고
//그럼 고객 정보가 가지런하게 뜸

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
//물건 정보를 dictionary에다가 넣는 방법
//디테일을 보여주고 productName을 통해서 모아줌

    public void SetCart(int cartID, int customerID, int totalCost, int orderID)
    {
        string key = "Cart_" + cartID
        myMap[key] = new { CustomerID = customerID, TotalCost = totalCost, OrderID = orderID };
    }
//쇼핑카트 디테일을 dictionary에 넣음

    public object GetCustomerInfo(string username)
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
//username을 통해서 고객 정보를 dictionary에서 가져옴
//username이 dictionary에 있는지 확인해줌, 있으면 customer object로 가고 없으면 customer not found

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
//물건 정보를 producName을 통해서 가져옴
//productName을 dictionary에 있는지 확인해줌, 있으면 product object로 가고 없으면 product not found

    public object GetCartInfo(int cartID)
    {
        string key = "Cart_" + cartID
        if (myMap.ContainsKey(key))
        {
            return myMap[key];
        }
        else
        {
            return "Cart not found.";
        }
    }
//카트 정보를 cartID를 통해서 가져옴

    public static void Main(string[] args)
    {
        Program program = new Program();
//program class variable program에 만들어짐

//고객 넣기
        program.SetCustomer("Jun", 1824, new int[] {1111});
        program.SetCustomer("Armon'e", 1825, new int[] {2222});

//물건  넣기
        program.SetProduct("T-Shirt", 1, 101, 500, "M", "Nike", "Long shirt", 4, 20, 10);
        program.SetProduct("Jeans", 2, 102, 1000, "L", "Adidas", "Long Jeans", 5, 15, 20);

//카트  넣기
        program.SetCart(1, 123, 1500, 301);

//고객 정보 나타내기
        Console.WriteLine("Customer Info for Jun:");
        Console.WriteLine(program.GetCustomerInfo("Jun"));

//물건 정보 나타내기
        Console.WriteLine("\nProduct Info for T-Shirt:");
        Console.WriteLine(program.GetProductInfo("T-Shirt"));

//카트 정보 나타내기
        Console.WriteLine("\nCart Info for Cart ID 1:");
        Console.WriteLine(program.GetCartInfo(1));
    }
}
//customers, products, and a cart들이 myMap에 추가됨
//Data 검색 방법 (GetCustomerInfo, GetProductInfo, GetCartInfo) are called to 모으다 and display the stored information.
