using homeWork9.Models;
namespace homeWork9.ViewModels;

public class MessageDetailsViewModel
{
    public MessageModel Message { get; set; }
    public string FromName { get; set; }
    public string ToName { get; set; }
    public string Title { get; set; }
    public string Header { get; set; }
}