namespace homeWork5;

public sealed class ScannerContext
{
    public ScannerContext(IScannerDevice device)
    {
        _device = device;                
    }

    private IScanOutputStrategy? _currentStrategy;
    private readonly IScannerDevice _device;

    public IScanOutputStrategy? CurrentStrategy
    {
        get => _currentStrategy;
        set => _currentStrategy = value;
    }

    public IScannerDevice Device
    {
        get => _device;
    }

    public void Execute(byte[] data, string filename = "")
    {
        //действия по контракту
        if (_device is null) throw new ArgumentNullException("Device can't be null");
        if (_currentStrategy is null) throw new ArgumentNullException("Current scan strategy can't be null");
        //
        if (string.IsNullOrWhiteSpace(filename))        
            filename = Guid.NewGuid().ToString();
        _currentStrategy.Save(filename, data);
    }
}