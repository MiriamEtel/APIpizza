using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Models;

namespace Services
{

public class PizzaService:IPizza
{
        static List<Pizza> Pizzas { get; set; }
        static int nextId = 4;
        public DateTime Date { get; set; }
        static PizzaService() => Pizzas = new List<Pizza>
 {
       new Pizza(){Id = 1, Gluten = true,Name="itali"},
       new Pizza(){Id = 2, Gluten = false,Name="olives and mashrooms"},
       new Pizza(){Id = 3, Gluten = true,Name="Mutzarela"}
 };

 public PizzaService()
 {
    Date=DateTime.Now;
 }

public string Stringi(){
  return "date from pizza:" +Date; 
}
  public Pizza? GetById(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
  public List<Pizza> Get() {return Pizzas;}
 
public ActionResult<List<Pizza>> Create(string name, bool gluten)
        {
            Pizza p = new Pizza() { Id = nextId++, Gluten = gluten, Name = name };
            Pizzas.Add(p);
            return Pizzas;
        }

       public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten)
        {
            foreach (var p in Pizzas)
            {
                if (p.Id == id)
                {
                    p.Name = name;
                    p.Gluten = gluten;
                    return Pizzas;
                }
            }
            return Pizzas;
        }

        public ActionResult<List<Pizza>> Delete(int id)
        {
            var pizza = GetById(id);
            if (pizza is null)
                return Pizzas;
            Pizzas.Remove(pizza);
            return Pizzas;
        }

        ActionResult<List<Pizza>> IPizza.Create(string name, bool gluten)
        {
            throw new NotImplementedException();
        }

        ActionResult<List<Pizza>> IPizza.UpDate(int id, string name, bool gluten)
        {
            throw new NotImplementedException();
        }

        ActionResult<List<Pizza>> IPizza.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

   