using homeWork9.Controllers.Requests;
using homeWork9.Models;
using System;
using System.Collections.Generic;
namespace homeWork9.Services.Interfaces;

public interface IMessageTypeService
{
    public bool RegisterMessageType(MessageTypeModel messageType);
    public MessageTypeModel? GetMessageType(int Id);
    public MessageTypeModel? GetMessageType(string Name);
    public List<MessageTypeModel>? GetMessageTypeAll();
}