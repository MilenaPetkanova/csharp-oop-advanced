using System;
using System.Collections.Generic;

public class ListyIterator<T> 
{
    private readonly List<T> elements;
    private int currentIndex;

    public ListyIterator(params T[] elements)
    {
        this.Reset();
        this.elements = new List<T>(elements);
    }

    public T Current => this.elements[this.currentIndex];

    public bool Move()
    {
        if (!this.HasNext())
        {
            return false;
        }

        this.currentIndex++;
        return true;
    }

    public bool HasNext() => this.currentIndex < this.elements.Count - 1;

    public void Reset() => this.currentIndex = 0;

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.Current);
    }
}