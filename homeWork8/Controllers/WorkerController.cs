using homeWork8.Models;
using homeWork8.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
//namespace homeWork8.Controller;

public class WorkerController: Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string Welcome()
    {
        return "";
    }

    public ViewResult Details()
    {
        ViewBag.Title = "";
        ViewBag.Header = "";

        var worker = new Worker() 
        {
            FirstName = "Michael",
            LastName = "Fassbender",
            Birthday = new DateOnly(1977, 04, 02),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };

        var address = new Address()
        {
            WorkerId = worker.Id,
            City = "Heidelberg",
            State = "Karlsruhe",
            Country = "Germany",
            Pin = "69126"
        };

        var workerDetailsViewModel = new WorkerDetailsViewModel()
        {
            Worker = worker,
            Address = address,
            Title = "Worker Details Page",
            Header = "Worker Details"
        };
        return View(workerDetailsViewModel);
    }       
}