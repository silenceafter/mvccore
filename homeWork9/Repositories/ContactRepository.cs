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
                if (GetContact(contact.EmailAddress) is null)
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
        }        
        return false;
    }

    public bool UpdateContact(int id, string emailaddress)
    {
        var contact = _context.Contacts
            .Where(row => row.Id == id)
            .SingleOrDefault();
        //
        if (contact is not null)
        {
            if (contact.EmailAddress.Trim().ToLower() != emailaddress.Trim().ToLower())
            {
                contact.EmailAddress = emailaddress;
                _context.SaveChanges();
                return true;
            }            
        }
        return false;
    }

    public ContactModel? GetContact(int id)
    {
        return _context.Contacts
            .Where(row => row.Id == id)
            .SingleOrDefault();
    }

    public ContactModel? GetContact(string emailaddress)
    {
        return _context.Contacts
            .Where(row => row.EmailAddress.Trim().ToLower() == emailaddress.Trim().ToLower())
            .SingleOrDefault();
    }

    public List<ContactModel>? GetContactAll()
    {
        return _context.Contacts.ToList();
    }
}