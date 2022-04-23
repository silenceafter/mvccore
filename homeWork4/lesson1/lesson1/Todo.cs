namespace lesson1;

public class Todo
{
    public Todo(ResponseTodo response)
    {
        _response = response;
    }

    private ResponseTodo _response;

    public ResponseTodo Response
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