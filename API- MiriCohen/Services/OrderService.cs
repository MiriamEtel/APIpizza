using System.Net.Http;
using Interfaces;
using Models;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using fileService;

namespace Services
{
    public class OrderService : Interfaces.IOrder{
      public DateTime Date {get;set;}

       public OrderService()
       {
        Date=DateTime.Now;
       }
      public string SendOrder(Order order)
      {
        DateTime Date=new DateTime();
        var jsonOrder=JsonSerializer.Serialize<Order>(order);
        return "The message was sent successfully"+jsonOrder;
      }

     public string Stringi() => "the date from order: " + Date;

  
    }
}