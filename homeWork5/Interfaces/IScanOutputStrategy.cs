namespace homeWork5;

public interface IScanOutputStrategy
{
    void Save(string filename, byte[] data);
}