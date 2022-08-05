using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace homeWork9.Models;

public class MessageModel
{
    public int Id { get; set; }

    [BindProperty]
    [Column(TypeName = "integer")]
    public int FromId { get; set; }

    [BindProperty]
    [Column(TypeName = "integer")]
    public int ToId { get; set; }

    [BindProperty]
    [Column(TypeName = "character(50)")]
    public string Theme { get; set; }

    [BindProperty]
    [Column(TypeName = "character varying")]
    public string Body { get; set; }

    [BindProperty]
    [Column(TypeName = "boolean")]
    public bool IsHtml { get; set; }

    [BindProperty]
    [Column(TypeName = "integer")]
    public int TypeId { get; set; } 
}