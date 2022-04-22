using lesson1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

var type1 = typeof(ResponseCompany);
var type2 = typeof(ResponseTodos);
if (type1 == type2) Console.WriteLine("1");
if (type1.Equals(type2)) Console.WriteLine("2");
//if (bb === vv) Console.WriteLine("2");
/*var jsonDownloader = new JsonDownloader<ResponseCompany>();
//companies
ResponseCompany company = null;
string link = "";
List<ResponseCompany> companies = new List<ResponseCompany>();
for(int i = 0; i < 5; i++)
{
    link = $"https://www.javaniceday.com/frandom/api/companies?quantity={1}";
    company = await jsonDownloader.Start<ResponseCompany>(link, i + 1);
    if (company is not null) 
    {
        companies.Add(company);
    }    
}*/

//todo
/*ResponseTodos todo = null;
List<ResponseTodos> todos = new List<ResponseTodos>();
for(int i = 0; i < 5; i++)
{
    link = $"https://jsonplaceholder.typicode.com/todos/{i + 1}";
    todo = await jsonDownloader.Start<ResponseTodos>(link, i + 1);
    if (todo is not null)
    {
        todos.Add(todo);
    }
}*/

Console.ReadLine();