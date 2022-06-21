using System;
using System.Collections.Generic;
namespace homeWork9.Controllers.Requests;
    
public class MessageRequest
{
    public string From { get; set; }
    public string To { get; set; }
    public string Theme { get; set; }
    public string Body { get; set; }
    public string IsHtml { get; set; }
}

    