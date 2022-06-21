using homeWork9.Controllers.Requests;
using homeWork9.Models;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories.Interfaces;

public interface IContactRepository
{
    public bool RegisterContact(ContactRequest contact);
    public ContactModel? GetContact(int Id);
    public List<ContactModel>? GetContactAll();
}