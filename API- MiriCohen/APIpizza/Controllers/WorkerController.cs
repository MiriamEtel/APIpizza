using Microsoft.AspNetCore.Mvc;
using Models;
using Interfaces;
using Services;

namespace APIpizza.Controllers{
[ApiController]
[Route("api/[controller]/[action]")]

public class WorkerController : ControllerBase
{
    IWorker _worker;
    public WorkerController (IWorker worker)
    {
        Console.WriteLine( _worker.Stringi());
        _worker=worker;
    }
}
}