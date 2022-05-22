//using homeWork8.Models;
//using homeWork8.Services;
//using homeWork8.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace homeWork8;

public class WorkerController: Controller
{
    public ViewResult Index()
    {
        ViewBag.Title = "";
        ViewBag.Header = "";
        var workersStore = new WorkerStore();

        //worker_one
        var worker_one = new Worker() {
            Id = workersStore.GetCount(),
            FirstName = "Michael",
            LastName = "Fassbender",
            Birthday = new DateOnly(1977, 04, 02),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };
        workersStore.AddWorker(worker_one);

        var address_one = new Address() {
            City = "Lisbon",
            State = "Estremadura",
            Country = "Portugal",
            Pin = "1149-014",
            WorkerId = worker_one.Id
        };
        workersStore.AddAddress(address_one);

        //viewModel_one
        var viewModel_one = new WorkerDetailsViewModel() {
            Worker = worker_one,
            Address = address_one,
            Title = "MyTitle",
            Header = "MyHeader"
        };

        //worker_two
        var worker_two = new Worker() {
            Id = workersStore.GetCount(),
            FirstName = "James",
            LastName = "McAvoy",
            Birthday = new DateOnly(1979, 04, 21),
            Age = 43,
            Gender = "M",
            Position = "Manager"
        };
        workersStore.AddWorker(worker_two);

        var address_two = new Address() {
            City = "London",
            State = "Greater London",
            Country = "England",
            Pin = "N1 0AA",
            WorkerId = worker_two.Id
        };
        workersStore.AddAddress(address_two);

        //viewModel_two
        var viewModel_two = new WorkerDetailsViewModel() {
            Worker = worker_two,
            Address = address_two,
            Title = "MyTitle",
            Header = "MyHeader"
        };

        //worker_three
        var worker_three = new Worker() {
            Id = workersStore.GetCount(),
            FirstName = "Anya-Josephine Marie",
            LastName = "Taylor-Joy",
            Birthday = new DateOnly(1996, 04, 16),
            Age = 26,
            Gender = "W",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_three);
        var address_three = new Address() {
            City = "Miami",
            State = "Florida",
            Country = "United States",
            Pin = "33101",
            WorkerId = worker_three.Id
        };
        workersStore.AddAddress(address_three);

        //viewModel_three
        var viewModel_three = new WorkerDetailsViewModel() {
            Worker = worker_three,
            Address = address_three,
            Title = "MyTitle",
            Header = "MyHeader"
        };

        //worker_four
        var worker_four = new Worker() {
            Id = workersStore.GetCount(),
            FirstName = "Cillian",
            LastName = "Murphy",
            Birthday = new DateOnly(1976, 05, 25),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };
        workersStore.AddWorker(worker_four);

        var address_four = new Address() {
            City = "Dublin",
            State = "Leinster",
            Country = "Ireland",
            Pin = "D01",
            WorkerId = worker_four.Id
        };
        workersStore.AddAddress(address_four);

        //viewModel_four
        var viewModel_four = new WorkerDetailsViewModel() {
            Worker = worker_four,
            Address = address_four,
            Title = "MyTitle",
            Header = "MyHeader"
        };

        //worker_five
        var worker_five = new Worker() {
            Id = workersStore.GetCount(),
            FirstName = "Emily Olivia Leah",
            LastName = "Blunt",
            Birthday = new DateOnly(1983, 02, 23),
            Age = 39,
            Gender = "W",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_five);
        
        var address_five = new Address() {
            City = "Los Angeles",
            State = "California",
            Country = "United States",
            Pin = "90001",
            WorkerId = worker_five.Id
        };
        workersStore.AddAddress(address_five);

        //viewModel_five
        var viewModel_five = new WorkerDetailsViewModel() {
            Worker = worker_five,
            Address = address_five,
            Title = "MyTitle",
            Header = "MyHeader"
        };

        var vv = new WorkerViewModel();
        vv.WorkerDetailsViewModels = new List<WorkerDetailsViewModel>();
        vv.WorkerDetailsViewModels.Add(viewModel_one);
        vv.WorkerDetailsViewModels.Add(viewModel_two);
        vv.WorkerDetailsViewModels.Add(viewModel_three);
        vv.WorkerDetailsViewModels.Add(viewModel_four);
        vv.WorkerDetailsViewModels.Add(viewModel_five);
        return View(vv);
    }

    public string Welcome()
    {
        return "";
    }

    public ViewResult Details()
    {
        ViewBag.Title = "";
        ViewBag.Header = "";

        var workersStore = new WorkerStore();
        //worker_one
        var worker_one = new Worker() {
            FirstName = "Michael",
            LastName = "Fassbender",
            Birthday = new DateOnly(1977, 04, 02),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_one);
        workersStore.AddAddress(new Address() {
            City = "Lisbon",
            State = "Estremadura",
            Country = "Portugal",
            Pin = "1149-014",
            WorkerId = worker_one.Id
        });

        //worker_two
        var worker_two = new Worker() {
            FirstName = "James",
            LastName = "McAvoy",
            Birthday = new DateOnly(1979, 04, 21),
            Age = 43,
            Gender = "M",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_two);
        workersStore.AddAddress(new Address() {
            City = "London",
            State = "Greater London",
            Country = "England",
            Pin = "N1 0AA",
            WorkerId = worker_two.Id
        });

        //worker_three
        var worker_three = new Worker() {
            FirstName = "Anya-Josephine Marie",
            LastName = "Taylor-Joy",
            Birthday = new DateOnly(1996, 04, 16),
            Age = 26,
            Gender = "W",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_three);
        workersStore.AddAddress(new Address() {
            City = "Miami",
            State = "Florida",
            Country = "United States",
            Pin = "33101",
            WorkerId = worker_three.Id
        });

        //worker_four
        var worker_four = new Worker() {
            FirstName = "Cillian",
            LastName = "Murphy",
            Birthday = new DateOnly(1976, 05, 25),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_four);
        workersStore.AddAddress(new Address() {
            City = "Dublin",
            State = "Leinster",
            Country = "Ireland",
            Pin = "D01",
            WorkerId = worker_four.Id
        });

        //worker_five
        var worker_five = new Worker() {
            FirstName = "Emily Olivia Leah",
            LastName = "Blunt",
            Birthday = new DateOnly(1983, 02, 23),
            Age = 39,
            Gender = "W",
            Position = "Manager"
        };

        workersStore.AddWorker(worker_five);
        workersStore.AddAddress(new Address() {
            City = "Los Angeles",
            State = "California",
            Country = "United States",
            Pin = "90001",
            WorkerId = worker_five.Id
        });

        /*var workerDetailsViewModel = new WorkerDetailsViewModel()
        {
            Worker = worker,
            Address = address,
            Title = "Worker Details Page",
            Header = "Worker Details"
        };*/
        return new ViewResult();//View(workerDetailsViewModel);
    }       
}