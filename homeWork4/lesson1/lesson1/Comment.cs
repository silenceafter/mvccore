namespace lesson1;

public class Comment
{
    public Comment(ResponseComment response)
    {
        _response = response;
    }

    private ResponseComment _response;

    public ResponseComment Response
    {
        get => _response;
        set => _response = value;
    }

    public string GetName()
    {
        if (_response != null)
        {
            return _response.name;
        }
        return "";
    }
}