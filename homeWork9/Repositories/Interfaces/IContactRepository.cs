using homeWork9.Controllers.Requests;
using homeWork9.Models;
using System;
using System.Collections.Generic;
namespace homeWork9.Repositories.Interfaces;

public interface IContactRepository
{
    public bool RegisterContact(ContactRequest contact);
    public bool UpdateContact(int id, string emailaddress);
    public bool DeleteContact(int id);
    public ContactModel? GetContact(int id);
    public ContactModel? GetContact (string emailaddress);
    public List<ContactModel>? GetContactAll();
}