using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Repositories.Interfaces;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly MessageContext _context;

    public MessageRepository(MessageContext context)
    {
        _context = context;
    }

    public bool RegisterMessage(MessageModel message)
    {
        var done = false;
        try 
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            done = true;
        }
        catch(Exception ex)
        {
            //logger
        }
        return done;
    }

    public MessageModel? GetMessage(int contactId, int messageId)
    {
        return _context.Messages
            .Where(row => row.ToId == contactId && row.Id == messageId)
            .SingleOrDefault();
    }

    public List<MessageModel>? GetMessageAll(int contactId)
    {
        return _context.Messages
            .Where(row => row.ToId == contactId || row.FromId == contactId)
            .ToList();
    }

    public List<MessageModel>? GetMessageAll(int contactId, int messageTypeId)
    {
        //входящие письма
        if (messageTypeId == 1)
            return _context.Messages
                .Where(row => row.ToId == contactId).ToList();

        //исходящие письма
        if (messageTypeId == 2)
            return _context.Messages
                .Where(row => row.FromId == contactId).ToList();
        return null;
    }
}