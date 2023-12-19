using Models;
using Interfaces;

namespace Services
{

public class WorkerService : IWorker
{
    public DateTime Date {get;set;}

    public WorkerService(){
        Date=DateTime.Now;
    }

    public string Stringi(){
        return "The date from worker:"+Date;
    }
}

}