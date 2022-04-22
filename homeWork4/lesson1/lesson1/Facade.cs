namespace lesson1;

public class Facade
{
    public Facade(ResponseCompany company)
    {
        _company = company;
    }

    private ResponseCompany? _company;

    public ResponseCompany Company
    {
        get => _company;
        set => _company = value;
    }

    public void GetNameAll()
    {
        //взять текст из полей name/title разных объектов
    }
}