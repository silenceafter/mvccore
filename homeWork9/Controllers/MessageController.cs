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
                    //from contact
                    var fromContact = _contactService.GetContact(message.FromId);
                    if (fromContact is null)
                        break;

                    //to contact
                    var toContact = _contactService.GetContact(message.ToId);
                    if (toContact is null)
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
                return View(viewModel);
            } 
        }        
        return View("Error");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<ViewResult> Create(
        [Bind("id")] int ContactId,
        [Bind("fromid")] int FromId,
        [Bind("toid")] int ToId,
        [Bind("theme")] string Theme,
        [Bind("body")] string Body,
        [Bind("ishtml")] bool IsHtml)
    {
        if (ModelState.IsValid)
        {
            MessageRequest messageRequest = new MessageRequest()
            {
                FromId = FromId,
                ToId = ToId,
                Theme = Theme,
                Body = Body,
                IsHtml = IsHtml
            };

            MessageViewModel viewModel = new MessageViewModel()
            {
                MessageDetailsViewModels = new List<MessageDetailsViewModel>()
            };

            
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
