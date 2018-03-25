using System.Collections.Generic;
using System.Linq;

public class Box<T> 
{
    private readonly IList<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count => this.items.Count;

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove()
    {
        var result = this.items.Last();
        this.items.RemoveAt(this.items.Count - 1);

        return result;
    }
}