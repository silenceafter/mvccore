using homeWork9.Models;
namespace homeWork9.ViewModels;

public class ContactDetailsViewModel
{
    public ContactModel Contact { get; set; }
    public string Title { get; set; }
    public string Header { get; set; }

    public void OnPost(string emailaddress)
    {
        Contact.EmailAddress = emailaddress;        
        var gg = 5;
    }
}