using System;
using System.Collections.Generic;
using homeWork9.Models;
using homeWork9.Repositories.Interfaces;
namespace homeWork9.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly MessageContext _context;

    public ContactRepository(MessageContext context)
    {
        _context = context;
    }

    public void RegisterContact()
    {
        return;
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