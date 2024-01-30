using System;
using System.Collections.Generic;

namespace Models{

public class Order{
    public string CustomerId {get;set;}
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
    public decimal Price  {get;set;}
}

public class PayCreditCard
{  public string num {get; set;}
   public string validity {get; set;}
   public string cvv {get; set;}
}

}