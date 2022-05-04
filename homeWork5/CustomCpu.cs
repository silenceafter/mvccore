[Serializable]
public class CustomCpu : ICpuData
{
    public CustomCpu(int percent, int threads, bool error)
    {
        _percent = percent;
        _threads = threads;
        _error = error;
    }

    private int _percent;
    private int _threads;
    private bool _error;

    public int Percent
    {
        get => _percent;
    }

    public int Threads
    {
        get => _threads;
    }

    public bool Error
    {
        get => _error;
    }
}