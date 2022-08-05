using System;
using System.Collections.Generic;
using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Repositories;
using homeWork9.Repositories.Interfaces;
using homeWork9.Services.Interfaces;
namespace homeWork9.Services;

public class MessageTypeService : IMessageTypeService
{
    private readonly IMessageTypeRepository _repository;

    public MessageTypeService(IMessageTypeRepository repository)
    {
        _repository = repository;
    }

    public bool RegisterMessageType(MessageTypeModel messageType)
    {
        return _repository.RegisterMessageType(messageType);
    }

    public MessageTypeModel? GetMessageType(int Id)
    {
        return _repository.GetMessageType(Id);
    }

    public MessageTypeModel? GetMessageType(string Name)
    {
        return _repository.GetMessageType(Name);
    }

    public List<MessageTypeModel>? GetMessageTypeAll()
    {
        return _repository.GetMessageTypeAll();
    }
}