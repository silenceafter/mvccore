namespace homeWork8;

public class DataStorage : IDataStorage
{
    private static int _counter = 0;

    public int GetCount()
    {
        _counter++;
        return _counter;
    }
}