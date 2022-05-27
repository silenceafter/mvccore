namespace homeWork8;

public interface IWorkersStore
{
    public void AddWorker(Worker worker);
    public void AddAddress(Address address);
    public Address? GetAddress(int id);
    public List<Address>? GetAddressAll();
    public int GetCount();
    public Worker? GetWorker(int id);
    public List<Worker>? GetWorkerAll();
}