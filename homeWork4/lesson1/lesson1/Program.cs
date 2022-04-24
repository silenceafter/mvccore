using lesson1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

var jsonDownloader = new JsonDownloader();
string link = "";
//todo = product source 1
ResponseTodo todo = null;
List<ResponseTodo> todos = new List<ResponseTodo>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/todos/{i + 1}";
    todo = await jsonDownloader.Start<ResponseTodo>(link, i + 1);
    if (todo is not null)
    {
        todos.Add(todo);
    }
}

//photo = product source 2
ResponsePhoto photo = null;
List<ResponsePhoto> photos = new List<ResponsePhoto>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/photos/{i + 1}";
    photo = await jsonDownloader.Start<ResponsePhoto>(link, i + 1);
    if (photo is not null)
    {
        photos.Add(photo);
    }
}

//comments = product source 3
ResponseComment comment = null;
List<ResponseComment> comments = new List<ResponseComment>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/comments/{i + 1}";
    comment = await jsonDownloader.Start<ResponseComment>(link, i + 1);
    if (comment is not null)
    {
        comments.Add(comment);
    }
}

//response to item_object
List<Todo> todoObjects = new List<Todo>();
foreach(var item in todos)
{
    todoObjects.Add(new Todo(item));
}

List<Photo> photoObjects = new List<Photo>();
foreach(var item in photos)
{
    photoObjects.Add(new Photo(item));
}

List<Comment> commentObjects = new List<Comment>();
foreach(var item in comments)
{
    commentObjects.Add(new Comment(item));
}

//facade
var facade = new Facade(todoObjects, photoObjects, commentObjects);
var names = facade.GetNameAll();

foreach(var name in names)
{
    Console.WriteLine($"product: {name}");
}
Console.ReadLine();