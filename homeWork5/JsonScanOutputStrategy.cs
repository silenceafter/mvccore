using System.Text;
using System.Text.Json;
namespace homeWork5;

public sealed class JsonScanOutputStrategy: IScanOutputStrategy
{
    public void Save(string filename, byte[] data)
    {                
        //название файла
        var sb = new StringBuilder(filename);
        sb.Append(".json");
        //
        if (!File.Exists(@sb.ToString()))
        {
            //создать файл
            string data_string = System.Text.UTF8Encoding.UTF8.GetString(data);
            File.WriteAllText(@sb.ToString(), data_string);
        }
    }
}