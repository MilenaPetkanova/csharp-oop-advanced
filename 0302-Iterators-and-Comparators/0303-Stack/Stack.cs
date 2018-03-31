using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private readonly List<T> stack;

    public Stack()
    {
        this.stack = new List<T>();
    }

    public void Push(params T[] elements)
    {
        this.stack.AddRange(elements);
    }

    public T Pop()
    {
        if (this.stack.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var poped = this.stack.Last();

        this.stack.RemoveAt(this.stack.Count - 1);

        return poped;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.stack.Count - 1; i >= 0; i--)
        {
            yield return this.stack[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

