using System;
using System.Collections.Generic;
using homeWork9.Models;
namespace homeWork9.Repositories.Interfaces;

public interface IMessageRepository
{
    public void RegisterMessage();
    public MessageModel? GetMessage(int contactId);
    public List<MessageModel>? GetMessageAll();
}