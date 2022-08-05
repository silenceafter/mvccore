using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace homeWork9.Models;

public class ContactModel
{
    public int Id { get; set; } 
    [BindProperty]
    [Column(TypeName = "character(50)")]
    public string EmailAddress { get; set; }
}