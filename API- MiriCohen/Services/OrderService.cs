using System.Net.Http;
using Interfaces;
using Models;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using fileService;

namespace Services
{
    public class OrderService : Interfaces.IOrder{

      IPizza _pz;
      IfileService<string> _fs;
      public DateTime Date {get;set;}

       public OrderService(IPizza pz,IfileService<string> fs)
       {
        Date=DateTime.Now;
        _pz=pz;
        _fs=fs;
        _fs.FileName="";
       }
       public string Stringi() => "the date from order: " + Date;

       public Order? Get(){
        return null;
       }


      public async Task<string> SendOrder(Order order)
      {
        DateTime Date=new DateTime();
        var jsonOrder=JsonSerializer.Serialize<Order>(order);
        var strp =payAsync(order);
        var strm=MakePizzaAsync(order.Items);
        string strp2=await strp;
        string strm2=await strm;
        Receipt(order);
        return strp2+strm2+jsonOrder;
      }

      public async Task<string> payAsync(Order order)
      {
        Console.WriteLine("Takes credit card information");
        await Task.Delay(1000);
        Console.WriteLine("Checks credit card details");
        await Task.Delay(1000);
         Console.WriteLine("Connects to the credit card company");
        await Task.Delay(4000);
         Console.WriteLine("Makes a payment");
        await Task.Delay(1000);
        Console.WriteLine("Disconnecting..");
        await Task.Delay(1000);
        return" The transaction was successfully completed!";
      }

      public async Task<string> MakePizzaAsync(List<OrderItem> items)
      {
        List<Pizza> Pizza=_pz.Get();
        foreach(OrderItem i in items){
          Pizza piz=Pizza.FirstOrDefault(pi => pi.Id == i.ItemId);
          if(piz!=null){
            for(int j=0;j< i.Quantity;j++){
              Console.WriteLine("Pizza"+piz.Name+"preparation begins");
              Console.WriteLine("Makes dough");
              Console.WriteLine("Add pizza sauce");
              Console.WriteLine("Add yellow cheese and toppings");
              Console.WriteLine("Bake the pizza");
              await Task.Delay(3000);
              Console.WriteLine("Pizza"+piz.Name+"is ready!");
            }
          }
        }
        return "With appetite!";
      }
      public void Receipt(Order ordr){
        List<Pizza> pizza=_pz.Get();
        string str=$"CustomerId: {ordr.CustomerId}, Date: {ordr.Date}\n ";
        foreach(OrderItem i in ordr.Items){
          Pizza piz=pizza.FirstOrDefault(pi =>pi.Id==i.ItemId);
          str+=$" pizza's id: {i.ItemId},pizza's name: {piz.Name} Quantity: {i.Quantity}, Price: {i.Price}\n";
        }
          str+=$" TotalAmount: {ordr.TotalAmount}\n thank you for buying in apiPIZZA!!!\n";
          _fs.FileName=Path.Combine("Mail",$"customer{ordr.CustomerId}");
          _fs.WriteLog(str);

        }
      }
    }
