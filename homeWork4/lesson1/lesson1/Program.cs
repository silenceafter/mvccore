using lesson1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

var jsonDownloader = new JsonDownloader();//<ResponseTodos,ResponsePhoto,ResponseAlbum>();
string link = "";
//todo
ResponseTodos todo = null;
List<ResponseTodos> todos = new List<ResponseTodos>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/todos/{i + 1}";
    todo = await jsonDownloader.Start<ResponseTodos>(link, i + 1);
    if (todo is not null)
    {
        todos.Add(todo);
    }
}

//photo
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

//albums
ResponseAlbum album = null;
List<ResponseAlbum> albums = new List<ResponseAlbum>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/albums/{i + 1}";
    album = await jsonDownloader.Start<ResponseAlbum>(link, i + 1);
    if (album is not null)
    {
        albums.Add(album);
    }
}

Console.ReadLine();