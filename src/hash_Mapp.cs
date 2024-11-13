using System;
using System.Collections.Generic; 

public partial class Program 
{
    Dictionary<object,object[]> myMap = new Dictionary<object, object[]>();

    
    public void set_Customer(string username, int address_ID, int [] card_ID) {
        myMap[username] = [address_ID, card_ID];
    }
    public void set_Products(string product_Name, int item_ID, int sale_ID, int item_weigh, string dimensions, string manufacture_Info, string item_description, int rating, int quantity, int photo_ID ) {
        myMap[product_Name] = [product_Name, item_ID, sale_ID, item_weigh, dimensions, manufacture_Info, item_description, rating, quantity, photo_ID];
    }
    public void set_Cart(int cart_ID, int cusotmer_ID, int total_Cost, int order_ID) {
        myMap[cart_ID] = [cusotmer_ID, total_Cost, order_ID];
    }


    public object get_Customer_Info(string username) {
        return myMap[username];
    }
    public object get_Products_Info(string product_Name) {
        return myMap[product_Name];
    }
    public object get_Cart_Info(int cart_ID) {
        return myMap[cart_ID];
    
    }
    
}
