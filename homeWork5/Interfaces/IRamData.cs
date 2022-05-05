namespace homeWork5;

public interface IRAMData
{
    int FreeMem { get; }
    int TotalMem { get; }
    bool Error { get; }
}