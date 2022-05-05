using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using homeWork5;

//logger
using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = loggerFactory.CreateLogger<ScannerContext>();

//1
var cpu_one = new CustomCpu(25, 4, false);//данные процессора
var ram_one = new CustomRAM(2048, 4096, false);//данные оперативной памяти
byte[] cpu_one_array, ram_one_array;

//2
var cpu_two = new CustomCpu(50, 4, false);
var ram_two = new CustomRAM(1024, 4096, false);
byte[] cpu_two_array, ram_two_array;

//3
var cpu_three = new CustomCpu(75, 4, false);
var ram_three = new CustomRAM(3035, 4096, false);
byte[] cpu_three_array, ram_three_array;

//создать сканер
var scanner = new CustomScannerDevice();
if (scanner != null)
{
    var scannerContext = new ScannerContext(scanner, logger);
    var device = scannerContext.Device;
    if (device != null)
    {
        //сканировать и передать байты
        //1
        cpu_one_array = device.Scan(cpu_one);
        ram_one_array = device.Scan(ram_one);

        //2
        cpu_two_array = device.Scan(cpu_two);
        ram_two_array = device.Scan(ram_two);

        //3
        cpu_three_array = device.Scan(cpu_three);
        ram_three_array = device.Scan(ram_three);
        
        //json
        var jsonStrategy = new JsonScanOutputStrategy();
        scannerContext.CurrentStrategy = jsonStrategy;
        //
        scannerContext.Execute(cpu_one_array);
        scannerContext.Execute(cpu_two_array);
        scannerContext.Execute(cpu_three_array);

        scannerContext.Execute(ram_one_array);
        scannerContext.Execute(ram_two_array);
        scannerContext.Execute(ram_three_array);

        //xml
        var xmlStrategy = new XmlScanOutputStrategy();
        scannerContext.CurrentStrategy = xmlStrategy;
        //
        scannerContext.Execute(cpu_one_array);
        scannerContext.Execute(cpu_two_array);
        scannerContext.Execute(cpu_three_array);

        scannerContext.Execute(ram_one_array);
        scannerContext.Execute(ram_two_array);
        scannerContext.Execute(ram_three_array);
    }    
}
Console.ReadLine();