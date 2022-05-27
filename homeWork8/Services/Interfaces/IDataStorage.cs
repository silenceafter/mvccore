namespace homeWork8;

public interface IDataStorage
{
    public Address? GetAddress(int id);
    public int GetCount();
    public int GetCountAll();
    public Worker? GetWorker(int id);
}