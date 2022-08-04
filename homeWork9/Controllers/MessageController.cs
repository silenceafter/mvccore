using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Services;
using homeWork9.Services.Interfaces;
using homeWork9.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace homeWork9.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMessageService _messageService;
    private readonly IContactService _contactService;

    public MessageController(
        ILogger<MessageController> logger, 
        IMessageService messageService, 
        IContactService contactService)
    {
        _logger = logger;
        _messageService = messageService;
        _contactService = contactService;
    }

//    [HttpGet]
    public ViewResult Index(int Id)
    {
        //входящие письма
        if (Id > 0)
        {
            var messages = _messageService.GetMessageAll(Id);
            if (messages is not null)
            {
                MessageViewModel viewModel = new MessageViewModel()
                {
                    MessageDetailsViewModels = new List<MessageDetailsViewModel>()
                };
                //
                foreach(var message in messages)
                {
                    //to contact
                    var toContact = _contactService.GetContact(message.ToId);
                    if (toContact is null)
                        break;

                    if (toContact.Id == Id)
                    {
                        //from contact
                        var fromContact = _contactService.GetContact(message.FromId);
                        if (fromContact is null)
                            break;                

                        viewModel.MessageDetailsViewModels.Add(
                            new MessageDetailsViewModel()
                            {
                                Message = new MessageModel()
                                {
                                    Id = message.Id,
                                    FromId = message.FromId,
                                    ToId = message.ToId,
                                    Theme = message.Theme,
                                    Body = message.Body,
                                    IsHtml = message.IsHtml
                                },
                                FromName = fromContact.EmailAddress,
                                ToName = toContact.EmailAddress,
                                Header = "",
                                Title = ""
                        });
                    }                    
                }
                return View(viewModel);
            } 
        }        
        return View("Error");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<ViewResult> Create([Bind("id")] int Id)
    {
        if (Id > 0)
        {
            //contact
            var contact = _contactService.GetContact(Id);
            if (contact is null)
                return View("Error");

            MessageDetailsViewModel viewModel = new MessageDetailsViewModel()
            {
                FromName = contact.EmailAddress,
                ToName = "",
                Message = null,
                Header = "",
                Title = ""
            };
            return View(viewModel);
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<ViewResult> Create(MessageRequest message)
    {
        if (message is not null)
        {
            if (!String.IsNullOrEmpty(message.FromName) && String.IsNullOrEmpty(message.ToName))
            {
                if (_messageService.RegisterMessage(message))
                    return View("Index");
            }                            
        }        
        return View("Error");
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
