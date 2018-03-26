using System;
using System.Collections.Generic;

public class Box<T>
{ 
    private readonly IEnumerable<T> items;
    private T item;

    public Box(T item)
    {
        this.items = new List<T>();
        this.item = item;
    }

    public override string ToString()
    {
        var output = $"{this.item.GetType().FullName}: {this.item}";

        return output;
    }
}