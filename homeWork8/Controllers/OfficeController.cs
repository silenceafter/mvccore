using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
//namespace homeWork8.Controller;

public class OfficeController: Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string Welcome()
    {
        return "";
    }
}