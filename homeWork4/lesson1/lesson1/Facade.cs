namespace lesson1;

public class Facade
{
    public Facade(List<Todo> todos, List<Photo> photos, List<Comment> comments)
    {
        _todos = todos;
        _photos = photos;
        _comments = comments;
    }

    private List<Todo> _todos;
    private List<Photo> _photos;
    private List<Comment> _comments;

    public List<Todo> Todos
    {
        get => _todos;
    }

    public List<Photo> Photos
    {
        get => _photos;
    }

    public List<Comment> Comments
    {
        get => _comments;
    }

    public List<string> GetNameAll()
    {
        //взять текст из полей name/title разных объектов
        var names = new List<string>();
        //todo
        for(int i = 0; i < _todos.Count; i++)
        {
            names.Add(_todos[i].Response.title);            
        }

        //photo
        for(int i = 0; i < _photos.Count; i++)
        {
            names.Add(_photos[i].Response.title);            
        }

        //comment
        for(int i = 0; i < _comments.Count; i++)
        {
            names.Add(_comments[i].Response.name);            
        }        
        return names;
    }
}