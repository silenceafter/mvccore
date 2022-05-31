using System;
using System.Collections.Generic;
using homeWork9.Models;
namespace homeWork9.Services.Interfaces;

public interface IContactService
{
    public void RegisterContact();
    public ContactModel? GetContact(int Id);
    public List<ContactModel>? GetContactAll();
}