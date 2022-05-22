using System.ComponentModel.DataAnnotations;
namespace homeWork8.Models;

public class Address
{
    public int WorkerId { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Pin { get; set; }
}