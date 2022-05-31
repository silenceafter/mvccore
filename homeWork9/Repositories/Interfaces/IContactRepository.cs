using System;
using System.Collections.Generic;
using homeWork9.Models;
namespace homeWork9.Repositories.Interfaces;

public interface IContactRepository
{
    public void RegisterContact();
    public ContactModel? GetContact(int Id);
    public List<ContactModel>? GetContactAll();
}