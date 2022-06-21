using System;
using System.Collections.Generic;
using homeWork9.Models;
namespace homeWork9.Services.Interfaces;

public interface IMessageService
{
    public void RegisterMessage();
    public MessageModel? GetMessage(int Id);
    public List<MessageModel>? GetMessageAll();
}