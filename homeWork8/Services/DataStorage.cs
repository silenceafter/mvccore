namespace homeWork8;

public class DataStorage : IDataStorage
{
    //хранилище с данными
    public DataStorage()
    {
        _workers = new List<Worker>();
        _addresses = new List<Address>();

        //worker_one
        var worker_one = new Worker() {
            Id = GetCount(),
            FirstName = "Michael",
            LastName = "Fassbender",
            Birthday = new DateOnly(1977, 04, 02),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };        

        var address_one = new Address() {
            City = "Lisbon",
            State = "Estremadura",
            Country = "Portugal",
            Pin = "1149-014",
            WorkerId = worker_one.Id
        };        

        //worker_two
        var worker_two = new Worker() {
            Id = GetCount(),
            FirstName = "James",
            LastName = "McAvoy",
            Birthday = new DateOnly(1979, 04, 21),
            Age = 43,
            Gender = "M",
            Position = "Manager"
        };        

        var address_two = new Address() {
            City = "London",
            State = "Greater London",
            Country = "England",
            Pin = "N1 0AA",
            WorkerId = worker_two.Id
        };        

        //worker_three
        var worker_three = new Worker() {
            Id = GetCount(),
            FirstName = "Anya-Josephine Marie",
            LastName = "Taylor-Joy",
            Birthday = new DateOnly(1996, 04, 16),
            Age = 26,
            Gender = "W",
            Position = "Manager"
        };

        var address_three = new Address() {
            City = "Miami",
            State = "Florida",
            Country = "United States",
            Pin = "33101",
            WorkerId = worker_three.Id
        };        

        //worker_four
        var worker_four = new Worker() {
            Id = GetCount(),
            FirstName = "Cillian",
            LastName = "Murphy",
            Birthday = new DateOnly(1976, 05, 25),
            Age = 45,
            Gender = "M",
            Position = "Manager"
        };        

        var address_four = new Address() {
            City = "Dublin",
            State = "Leinster",
            Country = "Ireland",
            Pin = "D01",
            WorkerId = worker_four.Id
        };        

        //worker_five
        var worker_five = new Worker() {
            Id = GetCount(),
            FirstName = "Emily Olivia Leah",
            LastName = "Blunt",
            Birthday = new DateOnly(1983, 02, 23),
            Age = 39,
            Gender = "W",
            Position = "Manager"
        };        
        
        var address_five = new Address() {
            City = "Los Angeles",
            State = "California",
            Country = "United States",
            Pin = "90001",
            WorkerId = worker_five.Id
        };

        _workers.Add(worker_one);
        _workers.Add(worker_two);
        _workers.Add(worker_three);
        _workers.Add(worker_four);
        _workers.Add(worker_five);
        _addresses.Add(address_one);
        _addresses.Add(address_two);
        _addresses.Add(address_three);
        _addresses.Add(address_four);
        _addresses.Add(address_five);
    }

    private static int _counter = 0;
    private List<Worker> _workers;
    private List<Address> _addresses;

    public List<Worker> Workers
    {
        get => _workers;
    }

    public List<Address> Addresses
    {
        get => _addresses;
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

    public int GetCountAll()
    {
        return _workers.Count;
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
}