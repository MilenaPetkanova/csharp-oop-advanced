using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    private T[] stones;

    public Lake(T[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<T> GetEnumerator()
    {
        // iterate even elements
        for (int i = 0; i < this.stones.Length; i += 2)
        {
            yield return this.stones[i];
        }

        // iterate odd elements backwards
        int length = this.stones.Length;
        var lastIndex = length % 2 == 0 ? length - 1 : length - 2;

        for (int i = lastIndex; i >= 1; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}