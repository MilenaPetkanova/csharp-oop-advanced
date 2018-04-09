using System;
using System.Collections.Generic;

public class ListIterator : IListIterator
{
    private List<string> iterator;
    private int internalIndex;

    public ListIterator()
    {
        throw new ArgumentNullException();
    }

    public ListIterator(IEnumerable<string> collection)
    {
        this.Iterator = new List<string>(collection);
        this.internalIndex = 0;
    }

    public List<string> Iterator
    {
        get => this.iterator; 
        set => this.iterator = value; 
    }

    public int InternalIndex => this.internalIndex; 

    public bool HasNext()
    {
        if (this.internalIndex == this.iterator.Count - 1)
        {
            return false;
        }

        return true;
    }

    public bool Move()
    {
        if (HasNext())
        {
            this.internalIndex++;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (this.iterator.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(GetElementAtInternalIndex());
    }

    public string GetElementAtInternalIndex()
    {
        return this.iterator[internalIndex];
    }
}
