using System;
using System.Collections.Generic;

namespace Models{

public class Order{
    public String CustomerId {get;set;}
    public DateTime Date {get;set;}
    public decimal TotalAmount {get;set;}
    public List<OrderItem> Items {get;set;}

    public Order(){
        Items=new List<OrderItem>();
    }
}

public class OrderItem
{
    public int ItemId {get;set;}
    public decimal Quantity {get;set;}
    public decimal price  {get;set;}
}

}