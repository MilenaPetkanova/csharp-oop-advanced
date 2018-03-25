using System;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {   
        T result = default(T);

        if (this.left.CompareTo(this.right) > 0)
        {
            result = this.left;
        }
        else if (this.left.CompareTo(this.right) < 0)
        {
            result = this.right;
        }

        return result;
    }
}