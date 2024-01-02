using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IPizza : ILifeTime
    {
        List<Pizza> Get();
        Pizza? GetById(int id);

       ActionResult<List<Pizza>> Create(string name,bool gluten,int price);
       ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price);
       ActionResult<List<Pizza>> Delete(int id);
    }
}
