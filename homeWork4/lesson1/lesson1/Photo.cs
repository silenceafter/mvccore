namespace lesson1;

public class Photo
{
    public Photo(ResponsePhoto response)
    {
        _response = response;
    }

    private ResponsePhoto _response;

    public ResponsePhoto Response
    {
        get => _response;
        set => _response = value;
    }

    public string GetName()
    {
        if (_response != null)
        {
            return _response.title;
        }
        return "";
    }
}