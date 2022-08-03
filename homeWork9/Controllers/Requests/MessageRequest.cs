using System;
using System.Collections.Generic;
namespace homeWork9.Controllers.Requests;
    
public class MessageRequest
{
    public int FromId { get; set; }
    public int ToId { get; set; }
    public string Theme { get; set; }
    public string Body { get; set; }
    public bool IsHtml { get; set; }
}

    