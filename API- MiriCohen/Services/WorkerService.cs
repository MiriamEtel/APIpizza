using Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using fileService;

namespace Services
{

public class WorkerService : Interfaces.IWorker
{
    static int nextId=0;
    private IfileService<Worker> _rwr;
    public DateTime Date {get;set;}

    public WorkerService(IfileService<Worker> rwr){
        _rwr=rwr;
        _rwr.FileName="worker.json";
        Date=DateTime.Now;
        List<Worker> w= _rwr.Read<Worker>();
        nextId=w.Count()+1;
    }

    public string Stringi(){
        return "The date from worker:"+Date;
    }

    public Worker? GetById(int id){
        return Get().FirstOrDefault(w => w.Id == id);
    }

    public List<Worker> Get(){
        return _rwr.Read<Worker>();
    }

    public void Create(string name,string password,string role)
    {
        Worker w =new Worker(nextId++,name,password,role);
        _rwr.Write<Worker>(w);
    }

    public ActionResult<List<Worker>> UpDate(int id ,string name,string password,string role)
    {
        List<Worker> work=Get();
        foreach (var w in work)
        {
            if(w.Id==id)
            {
                w.Name=name;
                w.Password = password;
                w.Role=role;
                _rwr.Update<Worker>(work);
            }
        }
        return work;
    }

    public void Delete(int id)
    { 
        List<Worker> work=Get();
        foreach(var w in work)
        {
            if(w.Id==id)
            {
                work.Remove(w);
                _rwr.Update<Worker>(work);
            }
        }

    }
}

}