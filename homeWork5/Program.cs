using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

//1
var cpu_one = new CustomCpu(25, 4, false);//данные процессора
var ram_one = new CustomRAM(2048, 4096, false);//данные оперативной памяти
byte[] cpu_one_array, ram_one_array;
//
cpu_one_array = Helper.GetBinaryArray(cpu_one);
ram_one_array = Helper.GetBinaryArray(ram_one);

//2
var cpu_two = new CustomCpu(50, 4, false);
var ram_two = new CustomRAM(1024, 4096, false);
byte[] cpu_two_array, ram_two_array;
//
cpu_two_array = Helper.GetBinaryArray(cpu_two);
ram_two_array = Helper.GetBinaryArray(ram_two);

//3
var cpu_three = new CustomCpu(75, 4, false);
var ram_three = new CustomRAM(3035, 4096, false);
byte[] cpu_three_array, ram_three_array;
//
cpu_three_array = Helper.GetBinaryArray(cpu_three);
ram_three_array = Helper.GetBinaryArray(ram_three);

//создать сканер
var scanner = new CustomScannerDevice();
if (scanner != null)
{
    /*var data = scanner.Scan();
    scanner.Data = data;*/
    var scannerContext = new ScannerContext(scanner);
    var device = scannerContext.Device;
    if (device != null)
    {
        //сканировать и передать байты
        var data = device.Scan();
        if (data != null) {
            //xml
            var xmlStrategy = new XmlScanOutputStrategy();
            scannerContext.CurrentStrategy = xmlStrategy;
            scannerContext.Execute();

            //json
        }
    }    
}
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
    Stream Scan();//Stream
}

public sealed class CustomScannerDevice : IScannerDevice
{
    private Stream? _data;

    public Stream? Data
    {
        get => _data;
        set => _data = value;
    }

    public Stream Scan()//Stream
    {
        //byte[] bytes = Encoding.ASCII.GetBytes("проверка");
        return new MemoryStream(Encoding.ASCII.GetBytes("проверка"));
    }
}

public sealed class ScannerContext
{
    public ScannerContext(IScannerDevice device)
    {
        _device = device;
    }

    private Stream? _data;
    private readonly IScannerDevice _device;
    private IScanOutputStrategy? _currentStrategy;


    public Stream? Data
    {
        get => _data;
        set => _data = value;
    }

    public IScannerDevice Device
    {
        get => _device;
    }

    public IScanOutputStrategy? CurrentStrategy
    {
        get => _currentStrategy;
        set => _currentStrategy = value;
    }

    public void Execute(string outputFilename = "", Stream data = null)
    {
        //действия по контракту
        if (_device is null) throw new ArgumentNullException("Device can't be null");
        if (_currentStrategy is null) throw new ArgumentNullException("Current scan strategy can't be null");
        if (string.IsNullOrWhiteSpace(outputFilename)) 
        {
            outputFilename = Guid.NewGuid().ToString();
        }
        //_currentStrategy.Data
        _currentStrategy.Scan(data);
        _currentStrategy.Save();
    }
}
 
public interface IScanOutputStrategy
{
    void Scan(Stream data);
    void Save();
}

public sealed class XmlScanOutputStrategy: IScanOutputStrategy
{
    public XmlScanOutputStrategy()
    {

    }

    public void Scan(Stream data)
    {
        //
    }

    public void Save()
    {
        //
    }
}

/*public class UserAccount
{
    public UserAccount(
        string name,
        string surname,
        string patronymic,
        int age,
        string position,
        string department
    )
    {
        Id = GetCount();
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Age = age;
        Position = position;
        Department = department;
    }

    private uint _cnt = 0;
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }

    private int GetCount()
    {
        _cnt++;
        return (int)_cnt;
    }
}*/

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