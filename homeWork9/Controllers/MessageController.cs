using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homeWork9.Models;

namespace homeWork9.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<MessageController> _logger;

    public MessageController(ILogger<MessageController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var messageViewModel = new MessageViewModel();
        messageViewModel.MessageDetailsViewModels = new List<MessageDetailsViewModel>();
        //
        /*var workers = _workerStore.GetWorkerAll();
        if (workers != null)
        {
            for(int i = 0; i <= workers.Count; i++)
            {
                var worker = _workerStore.GetWorker(i);
                var address = _workerStore.GetAddress(i);
                //
                if (worker != null && address != null)
                {
                    workerViewModel.WorkerDetailsViewModels.Add(new WorkerDetailsViewModel() {
                        Worker = worker,
                        Address = address,
                        Title = $"MyTitle{i}",
                        Header = $"MyHeader{i}"
                    });
                }                
            }
            return View(workerViewModel);
        }*/
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
