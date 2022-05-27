using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace homeWork8;

public class OfficeController: Controller
{
    private readonly IWorkersStore _workerStore;

    public OfficeController(IWorkersStore workersStore)
    {
        _workerStore = workersStore;
    }

    public ViewResult Index()
    {
        var workerViewModel = new WorkerViewModel();
        workerViewModel.WorkerDetailsViewModels = new List<WorkerDetailsViewModel>();
        //
        var workers = _workerStore.GetWorkerAll();
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
        }
        return View();
    }
}