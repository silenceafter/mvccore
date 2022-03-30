using System.Threading;

CustomList<int> tty = new CustomList<int>();
object locker = new object();

//thread1
Thread one = new Thread(new ParameterizedThreadStart(tty.Add));
one.Name = "Thread1";
one.Start(5);

//thread2
Thread two = new Thread(new ParameterizedThreadStart(tty.Add));
two.Name = "Thread2";
two.Start(10);

//thread3
Thread three = new Thread(new ParameterizedThreadStart(tty.Add));
three.Name = "Thread3";
three.Start(25);

//thread4
Thread four = new Thread(new ParameterizedThreadStart(tty.DeleteAt));
four.Name = "Thread4";
four.Start(0);

//ожидаем окончания работы потоков
one.Join();
two.Join();
three.Join();
four.Join();

//вывод на экран
for(int i = 0; i < tty.Count; i++)
{
    Console.WriteLine(tty.GetAt(i));
}

public class CustomList<T> : List<T>
{
    public CustomList()
    {
        _Locker = new object();
        _Size = 0;

        int initialCapacity = 8;
        //if (initialCapacity < 1) initialCapacity = 1;
        Capacity = initialCapacity;
        _Data = new T[Capacity];
    }

    private object _Locker;
    private int _Size;
    private T[] _Data;

    public object Locker
    {
        get => _Locker;
    }

    public new int Count
    {
        get => Size;
    }

    public int Size 
    { 
        get => _Size;
    }

    public T[] Data
    {
        get => _Data;
    }

    private void Resize()
    {
        //увеличиваем массив и переписываем данные
        T[] resized = new T[Capacity * 2];
        for (int i = 0; i < Capacity; i++)
        {
            resized[i] = _Data[i];
        }

        _Data = resized;
        Capacity *= 2;
    }

    private void ThrowIfIndexOutOfRange(int index)
    {
        if (index > Size - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException(string.Format($"Size = { 0 }", Size));
        }
    }

    public T GetAt(int index)
    {
        ThrowIfIndexOutOfRange(index);
        return Data[index];
    }

    public void Add(object? value)
    {
        var locker = _Locker;
        //
        lock (locker)
        {
            Thread.Sleep(3000);
            //
            if (value is not null)
            {
                if (_Size == Capacity)
                {
                    Resize();
                }
            
                _Data[_Size] = (T)value;
                _Size++;
                Console.WriteLine($"Добавлено { value } из { Thread.CurrentThread.Name } ");
            }            
        }
    }

    public void DeleteAt(object? value)
    {
        var locker = _Locker;        
        //
        lock (locker)
        {
            Thread.Sleep(3000);
            //
            var index = (int)value;
            ThrowIfIndexOutOfRange(index);
            var value_result = _Data[index];
            //
            for (int i = index; i < Size - 1; i++)
            {
                _Data[i] = _Data[i + 1];
            }
        
            _Data[Size - 1] = default(T);
            _Size--;
            Console.WriteLine($"Удалено { value_result } из { Thread.CurrentThread.Name } ");
        }
    }
}