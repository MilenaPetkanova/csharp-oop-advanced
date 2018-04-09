using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ListIteratorTests
{
    private const string TestArg = "TestArg";

    private ListIterator listIterator;
    private List<string> args;

    [SetUp]
    public void SetUp()
    {
        this.args = new List<string> { TestArg };
        this.listIterator = new ListIterator(args);
    }

    [Test]
    public void InitWithParams()
    {
        Assert.That(this.listIterator.Iterator.Count.Equals(1));
    }

    [Test]
    public void CannotInitWithNullParams()
    {
        Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator());
    }

    [Test]
    public void HasNextReturnsFalseWhenIndexIsLastElement()
    {
        Assert.IsFalse(this.listIterator.HasNext());
    }

    [Test]
    public void MoveIndexWhenHasNextElement()
    {
        this.listIterator = new ListIterator(new List<string> { TestArg, TestArg });

        this.listIterator.Move();

        Assert.That(this.listIterator.InternalIndex.Equals(1));
    }

    [Test]
    public void PrintElementAtCurrentInternalIndex()
    {
        Assert.AreEqual(this.listIterator.GetElementAtInternalIndex(), TestArg);
    }

    [Test]
    public void CannotPrintWhenEmptyCollction()
    {
        this.listIterator = new ListIterator(new List<string>());

        Assert.Throws<InvalidOperationException>(() => this.listIterator.Print(), "Invalid Operation!");
    }
}
