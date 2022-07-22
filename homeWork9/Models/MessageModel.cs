using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace homeWork9.Models;

public class MessageModel
{
    public int Id { get; set; }
    [BindProperty]
    public int FromId { get; set; }
    [BindProperty]
    public int ToId { get; set; }
    [BindProperty]
    public string Theme { get; set; }
    [BindProperty]
    public string Body { get; set; }
    [BindProperty]
    public bool IsHtml { get; set; }
}