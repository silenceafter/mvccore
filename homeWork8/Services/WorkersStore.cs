using homeWork8.Models;
using homeWork8.Services.Interfaces;
namespace homeWork8;

public class WorkerStore : IWorkerStore
{
    public WorkerStore()
    {
        _workers = new List<Worker>();
        _addresses = new List<Address>();
    }

    private List<Worker> _workers;
    private List<Address> _addresses;
    private static int _counter = 0;

    public List<Worker> Workers
    {
        get => _workers;
    }

    public List<Address> Addresses
    {
        get => _addresses;
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
    }

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
    }

    public Address? GetAddress(int Id)
    {
        foreach(var address in _addresses)
        {
            if (address.WorkerId == Id)
                return address;
        }
        return null;
    }

    public int GetCount()
    {
        _counter++;
        return _counter;
    }
}