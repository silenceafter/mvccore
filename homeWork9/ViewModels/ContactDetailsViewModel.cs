using homeWork9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace homeWork9.ViewModels;

public class ContactDetailsViewModel
{
    public ContactModel Contact { get; set; }
    public string Title { get; set; }
    public string Header { get; set; }
}