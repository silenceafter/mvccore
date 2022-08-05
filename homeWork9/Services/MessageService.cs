using System;
using System.Collections.Generic;
using homeWork9.Controllers.Requests;
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

    public bool RegisterMessage(MessageModel message)
    {
        return _repository.RegisterMessage(message);
    }

    public MessageModel? GetMessage(int contactId, int messageId)
    {
        return _repository.GetMessage(contactId, messageId);
    }

    public List<MessageModel>? GetMessageAll(int contactId)
    {
        return _repository.GetMessageAll(contactId);        
    }

    public List<MessageModel>? GetMessageAll(int contactId, int messageTypeId)
    {
        return _repository.GetMessageAll(contactId, messageTypeId);        
    }
}