namespace homeWork8;

public class WorkersStore : IWorkersStore
{
    public WorkersStore(IDataStorage dataStorage)
    {
        _dataStorage = dataStorage;
        //
        _workers = new List<Worker>();
        _addresses = new List<Address>();
        
        //заполнение значениями по умолчанию
        for(int i = 0; i <= _dataStorage.GetCountAll(); i++)
        {
            var worker = _dataStorage.GetWorker(i);
            if (worker is not null)
            {
                var address = _dataStorage.GetAddress(i);
                if (address is not null) 
                {
                    AddWorker(worker);
                    AddAddress(address);
                }                    
            }
        }
    }

    private List<Worker> _workers;
    private List<Address> _addresses;
    private static int _counter = 0;
    private readonly IDataStorage _dataStorage;

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

    public Address? GetAddress(int id)
    {
        foreach(var address in _addresses)
        {
            if (address.WorkerId == id)
                return address;
        }
        return null;
    }

    public int GetCount()
    {
        _counter++;
        return _counter;
    }

    public List<Address>? GetAddressAll()
    {
        return _addresses;
    }

    public Worker? GetWorker(int id)
    {
        foreach(var worker in _workers)
        {
            if (worker.Id == id)
                return worker;
        }
        return null;
    }

    public List<Worker>? GetWorkerAll()
    {
        return _workers;
    }
}