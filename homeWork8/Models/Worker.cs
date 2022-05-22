using System.ComponentModel.DataAnnotations;
//using homeWork8;
namespace homeWork8;

public class Worker
{
    public Worker()
    {
        Id = 0;
    }

    //private int _cnt = 0;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Position { get; set; }

    /*public int GetId()
    {
        _cnt++;
        return _cnt;
    }*/
}