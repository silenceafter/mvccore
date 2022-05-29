using System;
using System.Collections.Generic;
namespace homeWork9.Services.Interfaces;

public interface IMessageService
{
    public void RegisterMessage();
    public void GetMessage(int Id);
    public void GetMessageAll();
}