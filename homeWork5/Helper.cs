using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
namespace homeWork5;

public static class Helper
{
    public static byte[] GetBinaryArray(object current)
    {
        return JsonSerializer.SerializeToUtf8Bytes(current);
        /*BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, current);
            return ms.ToArray();
        }*/
    }
}