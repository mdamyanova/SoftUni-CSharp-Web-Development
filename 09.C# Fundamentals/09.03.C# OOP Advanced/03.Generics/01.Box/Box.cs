using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    public Box()
    {
        this.Data = new List<T>();
    }

    public List<T> Data { get; }

    public int Count => this.Data.Count;

    public void Add(T element)
    {
        this.Data.Add(element);
    }

    public T Remove()
    {
        var last = this.Data.Last();
        this.Data.RemoveAt(this.Data.Count - 1);
        return last;
    }
}