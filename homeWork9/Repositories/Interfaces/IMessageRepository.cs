using homeWork9.Controllers.Requests;
using homeWork9.Models;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories.Interfaces;

public interface IMessageRepository
{
    public bool RegisterMessage(MessageRequest message);
    public MessageModel? GetMessage(int contactId, int messageId);
    public List<MessageModel>? GetMessageAll(int contactId);
}