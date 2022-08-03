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

    public bool RegisterMessage(MessageRequest message)
    {
        /*if (message is not null)
        {
            try 
            {
                if (GetMessage(message.F) is null)
                {
                    _context.Contacts.Add(new ContactModel()
                    {
                        EmailAddress = contact.EmailAddress
                    });
                    _context.SaveChanges();
                }                
            }
            catch(Exception ex)
            {
                //logger
            }
            return true;            
        }*/       
        return false;
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
}