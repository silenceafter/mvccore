using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace homeWork8;

public class WorkerController: Controller
{
    private readonly IWorkersStore _workerStore;

    public WorkerController(IWorkersStore workersStore)
    {
        _workerStore = workersStore;
    }

    public ViewResult Index()
    {
        return View();
    }

    public ViewResult Details(int id)
    {
        ViewBag.Title = "Worker Details";
        ViewBag.Header = $"Worker {id}";
        //
        if (_workerStore is not null)
        {
            var worker = _workerStore.GetWorker(id);
            if (worker is not null)
            {
                var address = _workerStore.GetAddress(id);
                if (address is not null) 
                {
                    ViewBag.Title = $"{worker.FirstName} {worker.LastName}";

                    //viewModel
                    return View(new WorkerDetailsViewModel() {
                        Worker = worker,
                        Address = address,
                        Title = $"{worker.FirstName} {worker.LastName}",
                        Header = $"Worker details"
                    });
                }                    
            }
        }
        return View();
    }       
}