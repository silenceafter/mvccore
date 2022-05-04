using System.Runtime.Serialization.Formatters.Binary;

public static class Helper
{
    public static byte[] GetBinaryArray(object current)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, current);
            return ms.ToArray();
        }
    }
}