using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Interfaces;

namespace APIpizza.Controllers
{
[ApiController]
[Route("api/[controller]/[action]")]

public class PizzaController:ControllerBase
{ IPizza _pizza;

 public PizzaController(IPizza P){
    _pizza=P;
 }

 [HttpGet]
  public List<Pizza> Get()
  {  Console.WriteLine(_pizza.Stringi());
        return _pizza.Get();
  }

  [HttpGet("{id}")]
  public Pizza? GetById(int id)
  {     Console.WriteLine(_pizza.Stringi());
        return _pizza.GetById(id);
  }

//post
[HttpPost]
[Route("{name}/{gluten}/{price}")]
public ActionResult<List<Pizza>> Create(string name,bool gluten,int price){
    return _pizza.Create(name,gluten,price) ;
}

//put
[HttpPut]
[Route("{id}/{name}/{gluten}/{price}")]
public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price)
    {
        return _pizza.UpDate(id, name, gluten,price);
    }

//delete
 [HttpDelete("{id}")]
    public ActionResult<List<Pizza>> Delete(int id)
    {
        return _pizza.Delete(id);
    }

}

internal class Httpcreateattribute :Attribute
{

}


}