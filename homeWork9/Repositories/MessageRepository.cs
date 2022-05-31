using System;
using System.Collections.Generic;
using homeWork9.Models;
using homeWork9.Repositories.Interfaces;
namespace homeWork9.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly MessageContext _context;

    public MessageRepository(MessageContext context)
    {
        _context = context;
    }

    public void RegisterMessage()
    {
        return;
    }

    public MessageModel? GetMessage(int Id)
    {
        return _context.Messages
            .Where(row => row.Id == Id)
            .SingleOrDefault();
    }

    public List<MessageModel>? GetMessageAll()
    {
        return _context.Messages.ToList();
    }
}