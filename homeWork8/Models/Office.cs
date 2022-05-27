using System.ComponentModel.DataAnnotations;
namespace homeWork8.Models;

public class Office
{
    public List<Worker> Workers { get; set; }
}