using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.Repositories;
using homeWork9.Repositories.Interfaces;
using homeWork9.Services.Interfaces;
using homeWork9.ViewModels;
using System;
using System.Collections.Generic;
namespace homeWork9.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public bool RegisterContact(ContactRequest contact)
    {
        if (contact is null)
            return false;
        return _repository.RegisterContact(contact);
    }

    public ContactModel? GetContact(int Id)
    {
        return null;
    }

    public List<ContactModel>? GetContactAll()
    {
        return _repository.GetContactAll();
    }
}