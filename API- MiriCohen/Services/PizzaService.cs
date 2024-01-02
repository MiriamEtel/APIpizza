using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Models;
using fileService;

namespace Services
{

public class PizzaService:Interfaces.IPizza
{
        static List<Pizza> Pizzas { get; set; }
        static int nextId = 7;
        public DateTime Date { get; set; }
        readonly IfileService<Pizza> _rwr;


        public PizzaService(IfileService<Pizza> rwr)
        {
            this._rwr=rwr;
            Date=DateTime.Now;
            Pizzas=new List<Pizza>
          {
           new Pizza(){Id = 1, Gluten = true,Name="italy",Price=40},
           new Pizza(){Id = 2, Gluten = false,Name="olives and mashrooms",Price=45},
           new Pizza(){Id = 3, Gluten = true,Name="Mutzarela",Price=50}
          };
          List<Pizza> p=_rwr.Read(Path.Combine(Environment.CurrentDirectory,"File" ,"readwrite.txt"));
          nextId=p.Count()+1;
        }

public string Stringi(){
  return "date from pizza:" +Date; 
}

  public Pizza? GetById(int id)
  {
    return _rwr.Read(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt")).FirstOrDefault(p => p.Id == id);
  }
  public List<Pizza> Get() 
  {
        return _rwr.Read(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
  }
 
public ActionResult<List<Pizza>> Create(string name, bool gluten,int price)
        {
            Pizza p = new Pizza() { Id = nextId++, Gluten = gluten, Name = name ,Price=price};
            _rwr.Write(p,Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
            Pizzas.Add(p);
            return Pizzas;
        }

       public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price)
        {
            List<Pizza> Piz= _rwr.Read(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
            foreach (var p in Piz)
            {
                if (p.Id == id)
                {
                    p.Name = name;
                    p.Gluten = gluten;
                    p.Price = price;
                    _rwr.DeleteAll(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
                    foreach(var pi in Piz){
                    _rwr.Write(pi,Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
  
                    }
                }
            }
            return Piz;
        }

        public ActionResult<List<Pizza>> Delete(int id)
        {
          List<Pizza> Piz= _rwr.Read(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
          foreach (var p in Piz)
            {
                if (p.Id == id)
                { 
                    Piz.Remove(p);
                    _rwr.DeleteAll(Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
                    foreach(var pi in Piz){
                    _rwr.Write(p,Path.Combine(Environment.CurrentDirectory,"File","readwrite.txt"));
  
                    }
                }
            }
            return Piz;
        }

        

        // ActionResult<List<Pizza>> IPizza.Create(string name, bool gluten,int price)
        // {
        //     throw new NotImplementedException();
        // }

        // ActionResult<List<Pizza>> IPizza.UpDate(int id, string name, bool gluten,int price)
        // {
        //     throw new NotImplementedException();
        // }

        // ActionResult<List<Pizza>> IPizza.Delete(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}

   