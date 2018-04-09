//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

[TestFixture]
public class DatabaseTests
{
    private const int MaxCapacity = 16;
    private const int TestCapacity = 8;
    private const int TestNumber = 1;

    private Database database;

    [SetUp]
    public void InitDatabase()
    {
        this.database = new Database(new int[TestCapacity]);
    }

    [Test]
    public void InitNumbersByConstructor()
    {
        Assert.Throws<InvalidOperationException>(() => new Database(new int[MaxCapacity + 1]));
    }

    [Test]
    public void AddElementToNextFreeCell()
    {
        this.database.Add(TestNumber);

        Assert.That(this.database.LastElement.Equals(TestNumber) 
            || this.database.ArrayLength.Equals(TestCapacity + 1));
    }

    [Test]
    public void CannotAddElementWhenMaxCapacityIsExeeded()
    {
        this.database = new Database(new int[MaxCapacity]);

        Assert.Throws<InvalidOperationException>(() => this.database.Add(TestNumber));
    }

    [Test]
    public void RemoveLastElement()
    {
        this.database.Remove();

        Assert.That(this.database.ArrayLength.Equals(TestCapacity - 1));
    }

    [Test]
    public void CannotRemoveElementOfEmptyDatabase()
    {
        this.database = new Database(new int[0]);

        Assert.Throws<InvalidOperationException>(() => this.database.Remove());
    }

    [Test]
    public void FetchMethodReturnsSameArray()
    {
        int[] result = this.database.Fetch();

        Assert.That(result.Equals(this.database.Numbers));
    }
}

