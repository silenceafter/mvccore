using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Repositories.Interfaces;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly MessageContext _context;

    public ContactRepository(MessageContext context)
    {
        _context = context;
    }

    public bool RegisterContact(ContactRequest contact)
    {
        if (contact is not null)
        {
            try 
            {
                _context.Contacts.Add(new ContactModel()
                {
                    EmailAddress = contact.EmailAddress
                });
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                //logger
            }
            return true;            
        }        
        return false;
    }

    public ContactModel? GetContact(int Id)
    {
        return _context.Contacts
            .Where(row => row.Id == Id)
            .SingleOrDefault();
    }

    public List<ContactModel>? GetContactAll()
    {
        return _context.Contacts.ToList();
    }
}