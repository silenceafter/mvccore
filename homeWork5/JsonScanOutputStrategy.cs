using System.Text;
using System.Text.Json;
namespace homeWork5;

public sealed class JsonScanOutputStrategy: IScanOutputStrategy
{
    public void Save(string filename, byte[] data)
    {                
        //название файла
        if (string.IsNullOrWhiteSpace(filename)) throw new Exception("filename is empty");
        var sb = new StringBuilder();
        sb.Append(filename);
        sb.Append(".json");
        
        //создать файл
        string data_string = System.Text.UTF8Encoding.UTF8.GetString(data);
        File.WriteAllText(@sb.ToString(), data_string);        
    }
}