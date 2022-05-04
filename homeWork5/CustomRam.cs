[Serializable]
public class CustomRAM : IRAMData
{
    public CustomRAM(int freeMem, int totalMem, bool error)
    {
        _freeMem = freeMem;
        _totalMem = totalMem;
        _error = error;
    }

    private int _freeMem;
    private int _totalMem;
    private bool _error;

    public int FreeMem
    {
        get => _freeMem;
    }

    public int TotalMem
    {
        get => _totalMem;
    }

    public bool Error
    {
        get => _error;
    }    
}