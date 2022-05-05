using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
namespace homeWork5;

public sealed class ScannerContext
{
    public ScannerContext(IScannerDevice device, ILogger logger)
    {
        _device = device;
        _logger = logger;
    }

    private uint _cnt = 0;
    private IScanOutputStrategy? _currentStrategy;
    private readonly IScannerDevice _device;
    private readonly ILogger _logger;

    public IScanOutputStrategy? CurrentStrategy
    {
        get => _currentStrategy;
        set => _currentStrategy = value;
    }

    public IScannerDevice Device
    {
        get => _device;
    }

    public int GetCnt()
    {
        _cnt++;
        return (int)_cnt;
    }

    public void Execute(byte[] data, string filename = "")
    {
        //действия по контракту
        if (_device is null) throw new ArgumentNullException("Device can't be null");
        if (_currentStrategy is null) throw new ArgumentNullException("Current scan strategy can't be null");
        //        
        _logger.LogInformation($"ScannerContext.CurrentStrategy = { _currentStrategy }");
        if (string.IsNullOrWhiteSpace(filename))        
            filename = $"metric_{GetCnt()}";//Guid.NewGuid().ToString();         
        _currentStrategy.Save(filename, data);
        
    }
}