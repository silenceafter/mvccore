using homeWork8.Models;
namespace homeWork8.ViewModels;

public class WorkerDetailsViewModel
{
    public Worker Worker { get; set; }
    public Address Address { get; set; }
    public string Title { get; set; }
    public string Header { get; set; }
}