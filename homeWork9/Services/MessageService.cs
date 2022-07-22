using System;
using System.Collections.Generic;
using homeWork9.Models;
using homeWork9.Repositories;
using homeWork9.Repositories.Interfaces;
using homeWork9.Services.Interfaces;
namespace homeWork9.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _repository;

    public MessageService(IMessageRepository repository)
    {
        _repository = repository;
    }

    public void RegisterMessage()
    {

    }

    public MessageModel? GetMessage(int contactId)
    {
        return _repository.GetMessage(contactId);
    }

    public List<MessageModel>? GetMessageAll()
    {
        return _repository.GetMessageAll();        
    }
}