using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//1
var cpu_one = new CustomCpu(25, 4, false);//данные процессора
var ram_one = new CustomRAM(2048, 4096, false);//данные оперативной памяти
var metric_one = new ComputerMetric(cpu_one, ram_one);//метрики компьютера

//2
var cpu_two = new CustomCpu(50, 4, false);
var ram_two = new CustomRAM(1024, 4096, false);
var metric_two = new ComputerMetric(cpu_two, ram_two);

//3
var cpu_three = new CustomCpu(75, 4, false);
var ram_three = new CustomRAM(3035, 4096, false);
var metric_three = new ComputerMetric(cpu_three, ram_three);

//добавить метрики в объект компьютера
var computer_one = new CustomComputer();
computer_one.Metric.Add(metric_one);
computer_one.Metric.Add(metric_two);
computer_one.Metric.Add(metric_three);

//создать сканер
var scanner = new CustomScannerDevice();
var scannerContext = new ScannerContext(scanner);

var vv = new PdfScanOutputStrategy();
scannerContext.CurrentStrategy = vv;
scannerContext.Execute();
Console.ReadLine();

//метрики устройства
public interface ICpuData
{
    int Percent { get; }
    int Threads { get; }
    bool Error { get; }
}

public interface IRAMData
{
    int FreeMem { get; }
    int TotalMem { get; }
    bool Error { get; }
}

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

public class ComputerMetric
{
    public ComputerMetric(ICpuData cpu, IRAMData ram)
    {
        _cpu = cpu;
        _ram = ram;
    }

    private ICpuData _cpu;
    private IRAMData _ram;

    public ICpuData Cpu
    {
        get => _cpu;
    }

    public IRAMData RAM
    {
        get => _ram;
    }
}

public class CustomComputer
{
    public CustomComputer()
    {
        _metric = new List<ComputerMetric>();
    }

    private List<ComputerMetric> _metric;

    public List<ComputerMetric> Metric
    {
        get => _metric;
    }
}

//сканер
public interface IScannerDevice
{
    void Scan();//Stream
}

public sealed class CustomScannerDevice : IScannerDevice
{
    public CustomScannerDevice()
    {
    }

    public void Scan()//Stream
    {
        //
    }
}

public sealed class ScannerContext
{
    public ScannerContext(IScannerDevice device)
    {
        _device = device;
    }

    private readonly IScannerDevice _device;
    private IScanOutputStrategy _currentStrategy;

    public IScannerDevice Device
    {
        get => _device;
    }

    public IScanOutputStrategy CurrentStrategy
    {
        get => _currentStrategy;
        set => _currentStrategy = value;
    }

    public void Execute(string outputFilename = "")
    {
        //действия по контракту
        if (_device is null) throw new ArgumentNullException("Device can't be null");
        if (_currentStrategy is null) throw new ArgumentNullException("Current scan strategy can't be null");
        if (string.IsNullOrWhiteSpace(outputFilename)) 
        {
            outputFilename = Guid.NewGuid().ToString();
        }
        _currentStrategy.Scan();
        _currentStrategy.Save();
    }
}
 
public interface IScanOutputStrategy
{
    void Scan();
    void Save();
}

public sealed class PdfScanOutputStrategy: IScanOutputStrategy
{
    public void Scan()
    {
        //
    }

    public void Save()
    {
        //
    }
}