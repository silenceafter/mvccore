using System;
using System.Collections.Generic;
using homeWork9.Models;
using homeWork9.Repositories;
using homeWork9.Repositories.Interfaces;
using homeWork9.Services.Interfaces;
namespace homeWork9.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public void RegisterContact()
    {

    }

    public ContactModel? GetContact(int Id)
    {
        return null;
    }

    public List<ContactModel>? GetContactAll()
    {
        return null;
    }
}