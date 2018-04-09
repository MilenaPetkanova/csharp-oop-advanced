using System;

public class Database : IDatabase
{
    private int[] numbers;

    public Database(params int[] nums)
    {
        this.Numbers = nums;
    }

    public int ArrayLength => this.numbers.Length;

    public int LastElement => this.numbers[ArrayLength - 1];

    public int[] Numbers
    {
        get => this.numbers;
        set
        {
            if (value.Length > 16)
            {
                throw new InvalidOperationException("Max capacity of the collectin is 16.");
            }
            this.numbers = value;
        }
    }

    public void Add(int number)
    {
        if (this.numbers.Length == 16)
        {
            throw new InvalidOperationException("The Database is already filled.");
        }

        this.numbers = AddToArray(this.numbers, number);
    }

    public void Remove()
    {
        if (this.numbers.Length == 0)
        {
            throw new InvalidOperationException("The Database is empty.");
        }

        int removeAt = this.numbers.Length - 1;
        this.numbers = RemoveIndices(this.numbers, removeAt);
    }

    public int[] Fetch()
    {
        return this.numbers;
    }

    private int[] RemoveIndices(int[] indcesArray, int removeAt)
    {
        int[] newIndicesArray = new int[indcesArray.Length - 1];

        int i = 0;
        int j = 0;
        while (i < indcesArray.Length)
        {
            if (i != removeAt)
            {
                newIndicesArray[j] = indcesArray[i];
                j++;
            }

            i++;
        }

        return newIndicesArray;
    }

    public static T[] AddToArray<T>(T[] array, T item)
    {
        T[] returnarray = new T[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            returnarray[i] = array[i];
        }
        returnarray[array.Length] = item;
        return returnarray;
    }
}