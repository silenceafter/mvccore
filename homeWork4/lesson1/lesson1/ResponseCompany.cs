//using lesson1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
namespace lesson1;
public class ResponseCompany
{
    //https://www.javaniceday.com/frandom/api/companies?countryCode=mx&quantity=1
    public string code { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string displayName { get; set; }

    /*public ResponseCompanies First()
    {
        return new ResponseCompanies();
    }*/
}