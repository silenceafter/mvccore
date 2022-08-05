using System;
using System.Collections.Generic;
namespace homeWork9.Controllers.Requests;
    
public class MessageRequest
{
    public string FromName { get; set; }
    public string ToName { get; set; }
    public string Theme { get; set; }
    public string Body { get; set; }
    public bool IsHtml { get; set; }
    public string Type { get; set; }
}

    