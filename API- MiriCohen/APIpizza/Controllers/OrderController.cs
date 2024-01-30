using Microsoft.AspNetCore.Mvc;
using Models;
using Interfaces;
using Services;

namespace APIpizza.Controllers{
[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    IOrder _order;
    public OrderController(IOrder order){
       _order=order; 
    }

[HttpPost]
[Route("{order}")]
public async Task<string> sendOrder(Order order){
   Console.WriteLine(_order.Stringi());
        return await _order.SendOrder(order);
}

}

}