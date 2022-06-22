using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Services;
using homeWork9.Services.Interfaces;
using homeWork9.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

    [HttpGet]
    public ViewResult Index(string? emailaddress)
    {
        return View();
    }

    //[HttpPost]
    public async Task<ViewResult> Create([Bind("emailaddress")] string emailaddress)
    {
        if (ModelState.IsValid) {
            var contactRequest = new ContactRequest()
            {
                EmailAddress = emailaddress
            };

            //_service.RegisterContact(contactRequest);
            if (_service.RegisterContact(contactRequest)) 
            {
                /*var viewModel = new ContactViewModel()
                {
                    ContactDetailsViewModels = new List<ContactDetailsViewModel>()
                };*/

                var contacts = _service.GetContactAll();
            }
            //return RedirectToAction("Index", "Contact", new { emailaddress = emailaddress });//return RedirectToAction("Index", "Contact", null);
        }
        return View();
    }
}