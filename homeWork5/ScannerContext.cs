public sealed class ScannerContext
{
    public ScannerContext(IScannerDevice device, string filename = "")
    {
        _device = device;        
        //
        if (string.IsNullOrWhiteSpace(filename))        
            _filename = Guid.NewGuid().ToString();
        else
            _filename = filename;
    }

    private IScanOutputStrategy? _currentStrategy;
    private readonly IScannerDevice _device;
    private string _filename;

    public IScanOutputStrategy? CurrentStrategy
    {
        get => _currentStrategy;
        set => _currentStrategy = value;
    }

    public IScannerDevice Device
    {
        get => _device;
    }

    public string Filename
    {
        get => _filename;
    }

    public void Execute(byte[] data)
    {
        //действия по контракту
        if (_device is null) throw new ArgumentNullException("Device can't be null");
        if (_currentStrategy is null) throw new ArgumentNullException("Current scan strategy can't be null");        
        _currentStrategy.Save(data);
    }
}