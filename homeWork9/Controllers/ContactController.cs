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
    public ViewResult Index()
    {
        var contacts = _service.GetContactAll();
        if (contacts is not null)
        {
            ContactViewModel viewModel = new ContactViewModel()
            {
                ContactDetailsViewModels = new List<ContactDetailsViewModel>()
            };
            //
            foreach(var contact in contacts)
            {
                viewModel.ContactDetailsViewModels.Add(
                    new ContactDetailsViewModel()
                    {
                        Contact = new ContactModel()
                        {
                            Id = contact.Id,
                            EmailAddress = contact.EmailAddress
                        },
                        Header = "",
                        Title = ""
                    });
            }
            return View(viewModel);
        }
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
            
            ContactViewModel viewModel = new ContactViewModel()
            {
                ContactDetailsViewModels = new List<ContactDetailsViewModel>()
            };
            //
            if (_service.RegisterContact(contactRequest)) 
            {
                var contacts = _service.GetContactAll();
                if (contacts != null)
                {
                    foreach(var contact in contacts)
                    {
                        viewModel.ContactDetailsViewModels.Add(
                            new ContactDetailsViewModel()
                            {
                                Contact = new ContactModel()
                                {
                                    Id = contact.Id,
                                    EmailAddress = contact.EmailAddress
                                },
                                Header = "",
                                Title = ""
                            });
                    }
                }            
            }
            return View("All", viewModel);
        }
        return View();
    }

    [HttpGet]
    public ViewResult Edit(int id)
    {
        if (id > 0)
        {
            var contact = _service.GetContact(id);
            if (contact is not null) 
            {
                ContactDetailsViewModel viewModel = new ContactDetailsViewModel()
                {
                    Contact = new ContactModel()
                    {
                        Id = contact.Id,
                        EmailAddress = contact.EmailAddress                
                    },
                    Header = "",
                    Title = ""
                };
                return View(viewModel);
            }
        }
        return View();
    }

    [HttpPost]
    public async Task<ViewResult> Edit(int id, [Bind("emailaddress")] string emailaddress)
    {
        if (id > 0 && emailaddress.Trim() != "")
        {
            if (_service.UpdateContact(id, emailaddress))
            {
                ContactViewModel viewModel = new ContactViewModel()
                {
                    ContactDetailsViewModels = new List<ContactDetailsViewModel>()
                };
                //
                var contacts = _service.GetContactAll();
                if (contacts != null)
                {
                    foreach(var contact in contacts)
                    {
                        viewModel.ContactDetailsViewModels.Add(
                            new ContactDetailsViewModel()
                            {
                                Contact = new ContactModel()
                                {
                                    Id = contact.Id,
                                    EmailAddress = contact.EmailAddress
                                },
                                Header = "",
                                Title = ""
                            });
                    }
                }
                return View("All", viewModel);
            }
        }
        return View();
    }

    [HttpPut]
    public ViewResult Edit(string? jj)
    {
        return View();
    }
}