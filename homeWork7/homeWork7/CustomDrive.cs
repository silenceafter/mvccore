using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace homeWork7;

public enum CDriveType
{
    CDRom,
    Fixed,
    Network,
    NoRootDirectory,
    Ram,
    Removable,
    Unknown
}

public enum FileSystemType
{
    exFAT,
    FAT12,
    FAT16,
    FAT32,
    HPFS,
    NTFS
}

public class CustomDrive
{
    public CustomDrive(
        string name,
        CDriveType type,
        FileSystemType filesystem,
        long totalMemory,
        long usedMemory,
        string volumeNumber)
    {
        _name = name;
        _type = type;
        _filesystem = filesystem;
        _totalMemory = totalMemory;
        _usedMemory = usedMemory;
        _freeMemory = GetFreeMemory(usedMemory, totalMemory);
        _percentOfFreeMemory = GetPercentOfFreeMemory(_freeMemory, totalMemory);
        _volumeNumber = volumeNumber;
    }

    private string _name;
    private CDriveType _type;
    private FileSystemType _filesystem;
    private long _totalMemory;//MB
    private long _usedMemory;//MB
    private long _freeMemory;//MB
    private uint _percentOfFreeMemory;
    private string _volumeNumber;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public CDriveType Type
    {
        get => _type;
        set => _type = value;
    }

    public FileSystemType Filesystem
    {
        get => _filesystem;
        set => _filesystem = value;
    }

    public long TotalMemory
    {
        get => _totalMemory;
        set => _totalMemory = value;
    }

    public long UsedMemory
    {
        get => _usedMemory;
        set => _usedMemory = value;
    }

    public long FreeMemory
    {
        get => _freeMemory;
        set => _freeMemory = value;
    }

    public uint PercentOfFreeMemory
    {
        get => _percentOfFreeMemory;
    }

    public string VolumeNumber
    {
        get => _volumeNumber;
        set => _volumeNumber = value;
    }

    public long GetFreeMemory(long usedMemory, long totalMemory)
    {
        return totalMemory - usedMemory;
    }

    public uint GetPercentOfFreeMemory(long freeMemory, long totalMemory)
    {
        return (uint)((double)freeMemory / (double)totalMemory * 100);
    }
}