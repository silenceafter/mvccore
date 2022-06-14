using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homeWork9.Models;
using homeWork9.Services;
using homeWork9.Services.Interfaces;
namespace homeWork9.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private readonly IContactService _service;

    public ContactController(ILogger<ContactController> logger, IContactService service)
    {
        _logger = logger;
        _service = service;
    }

    public ViewResult Index()
    {
        return View();
    }

    //[HttpPost]
    public ViewResult Create(string emailaddress)
    {
        return View();
    }
}