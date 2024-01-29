using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Models;
using Interfaces;
using Services; 
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace APIpizza.Controllers
{
[ApiController]
[Route("api/[controller]/[action]")]

public class PizzaController:ControllerBase
{
    readonly IPizza _pizza;
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
public ActionResult<List<Pizza>> Create([StringLength(23)]string name,bool gluten,[Range(15,150)]int price){
    return _pizza.Create(name,gluten,price) ;
}

//put
[HttpPut]
[Route("{id}/{name}/{gluten}/{price}")]
[Authorize(Policy = "SuperWorker")]
public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price)
    {
        return _pizza.UpDate(id, name, gluten,price);
    }

//delete
 [HttpDelete("{id}")]
 [Authorize(Policy = "SuperWorker")]
    public void Delete(int id)
    {
         _pizza.Delete(id);
    }

}

internal class Httpcreateattribute :Attribute
{

}


}