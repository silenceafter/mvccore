using homeWork9.Controllers.Requests;
using homeWork9.Models;
using homeWork9.ViewModels;
using System;
using System.Collections.Generic;
namespace homeWork9.Services.Interfaces;

public interface IContactService
{
    public bool RegisterContact(ContactRequest contact);
    public ContactModel? GetContact(int Id);
    public List<ContactModel>? GetContactAll();
}