using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homeWork9.Models;
using homeWork9.Services;
using homeWork9.Services.Interfaces;
using homeWork9.ViewModels;
namespace homeWork9.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMessageService _service;

    public MessageController(ILogger<MessageController> logger, IMessageService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public ViewResult Index([Bind("toid")] int toId)
    {
        if (toId > 0)
        {
            var message = _service.GetMessage(toId);
            /*if (message is not null)
            {
                MessageViewModel viewModel = new MessageViewModel()
                {
                    MessageDetailsViewModels = new List<MessageDetailsViewModel>()
                };
                //
                foreach(var message in messages)
                {
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
                            Header = "",
                            Title = ""
                        });
                }
                return View(viewModel);
            }*/
        }    
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
