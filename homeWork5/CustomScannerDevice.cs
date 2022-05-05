namespace homeWork5;

public sealed class CustomScannerDevice : IScannerDevice
{
    private Stream? _data;

    public Stream? Data
    {
        get => _data;
        set => _data = value;
    }

    public byte[] Scan(object data)//Stream
    {
        if (data is null) throw new NullReferenceException();
        return Helper.GetBinaryArray(data);
    }
}