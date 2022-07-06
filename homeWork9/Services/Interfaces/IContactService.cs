using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.ViewModels;
using System;
using System.Collections.Generic;
namespace homeWork9.Services.Interfaces;

public interface IContactService
{
    public bool RegisterContact(ContactRequest contact);
    public bool UpdateContact(int id, string emailaddress);
    public bool DeleteContact(int id);
    public ContactModel? GetContact(int id);
    public List<ContactModel>? GetContactAll();
}