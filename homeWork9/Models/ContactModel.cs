using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace homeWork9.Models;

public class ContactModel
{
    public int Id { get; set; }
    [Required, StringLength(20)]
    public string EmailAddress { get; set; }
}