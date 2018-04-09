using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class DatabaseTests
{
    private const int MaxCapacity = 16;
    private const string TestUsername = "SomeUsername";
    private const long TestId = 1;

    private Person fakePerson;
    private Person anotherFakePerson;
    private Person personWithSameId;
    private Person personWithSameUsername;
    private List<Person> people;
    private Database database;

    [SetUp]
    public void Initialize()
    {
        this.fakePerson = new Person(TestId, TestUsername);
        this.anotherFakePerson = new Person(TestId + 1, TestUsername + "Another");
        this.personWithSameId = new Person(TestId, TestUsername + "Diferent");
        this.personWithSameUsername = new Person(TestId + 2, TestUsername);

        this.people = new List<Person> { fakePerson };

        this.database = new Database(this.people);
    }

    [Test]
    public void InitDatabaseWithEmptyConstructor()
    {
        Assert.DoesNotThrow(() => new Database());
    }

    [Test]
    public void InitDatabaseWithPeopleParamsConstructor()
    {
        Assert.That(this.people.Count.Equals(1));
    }

    [Test]
    public void AddElementToNextFreeCell()
    {
        this.database.Add(this.anotherFakePerson);

        Assert.That(this.database.People.Last().Equals(this.anotherFakePerson));
    }

    [Test]
    public void CannotAddPersonWithAlreatyExistingId()
    {
        Assert.Throws<InvalidOperationException>(() => this.database.Add(this.personWithSameId));
    }

    [Test]
    public void CannotAddPersonWithAlreatyExistingUsername()
    {
        Assert.Throws<InvalidOperationException>(() => this.database.Add(this.personWithSameUsername));
    }

    [Test]
    public void RemoveLastElement()
    {
        var lengthBeforeRemoval = this.database.People.Count;

        this.database.Add(anotherFakePerson);
        this.database.Remove();

        Assert.That(this.database.People.Count.Equals(lengthBeforeRemoval));
    }

    [Test]
    public void CannotRemoveElementOfEmptyDatabase()
    {
        this.database = new Database();

        Assert.Throws<InvalidOperationException>(() => this.database.Remove());
    }

    [Test]
    public void FetchMethodReturnsSameColeection()
    {
        var fetchingResult = this.database.Fetch();

        Assert.That(fetchingResult.Equals(this.database.People));
    }
    
    [Test]
    public void CannotFindByUsernameParamDoesNotMatch()
    {
        Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(TestUsername + "DoesNotMatch"));
    }

    [Test]
    public void CannotFindByNullUsernameParam()
    {
        Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
    }
    
    [Test]
    public void FindByUsernameIsCaseSensitive()
    {
        var uppercaseUsername = TestUsername.ToUpper();

        Assert.DoesNotThrow(() => this.database.FindByUsername(uppercaseUsername));
    }

    [Test]
    public void CannotFindByIdWhenIdParamDoesNotMatch()
    {
        Assert.Throws<InvalidOperationException>(() => this.database.FindById(TestId + 666));
    }

    [Test]
    public void CannotFindByNegativeIdParam()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(TestId - 666));
    }
}

