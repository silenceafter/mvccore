using homeWork9.Models;
namespace homeWork9;

public class ContactDetailsViewModel
{
    public ContactModel Contact { get; set; }
    public string Title { get; set; }
    public string Header { get; set; }

    public void OnPost(ContactModel Contact)
    {

    }
}