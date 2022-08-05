using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Repositories.Interfaces;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories;

public class MessageTypeRepository : IMessageTypeRepository
{
    private readonly MessageContext _context;

    public MessageTypeRepository(MessageContext context)
    {
        _context = context;
    }

    public bool RegisterMessageType(MessageTypeModel messageType)
    {
        var done = false;
        try 
        {
            _context.MessageTypes.Add(messageType);
            _context.SaveChanges();
            done = true;
        }
        catch(Exception ex)
        {
            //logger
        }
        return done;
    }

    public MessageTypeModel? GetMessageType(int Id)
    {
        return _context.MessageTypes
            .Where(row => row.Id == Id)
            .SingleOrDefault();
    }

    public MessageTypeModel? GetMessageType(string Name)
    {
        return _context.MessageTypes
            .Where(row => row.Name == Name.Trim().ToUpper())
            .SingleOrDefault();
    }

    public List<MessageTypeModel>? GetMessageTypeAll()
    {
        return _context.MessageTypes.ToList();
    }
}