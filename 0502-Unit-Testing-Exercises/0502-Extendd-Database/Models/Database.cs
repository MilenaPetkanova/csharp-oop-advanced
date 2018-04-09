using System;
using System.Collections.Generic;
using System.Linq;

public class Database : IDatabase
{
    private IList<Person> people;

    public Database()
    {
        this.people = new List<Person>();
    }

    public Database(IEnumerable<Person> people)
        : this()
    {
        this.people = (IList<Person>)people;
    }

    public IList<Person> People
    {
        get => this.people;
        set
        {
            if (value.Count > 16)
            {
                throw new InvalidOperationException("Max capacity of the collectin is 16.");
            }
            this.people = value;
        }
    }

    public void Add(Person person)
    {
        var dublicate = this.people.FirstOrDefault(p => p.Id == person.Id || p.Username == person.Username);
        if (dublicate != null)
        {
            throw new InvalidOperationException("Already exists person with the same username or id.");
        }

        else if (this.people.Count == 16)
        {
            throw new InvalidOperationException("Max capacity of the collectin is 16.");
        }

        this.people.Add(person);
    }

    public void Remove()
    {
        if (this.people.Count == 0)
        {
            throw new InvalidOperationException("The Database is empty.");
        }

        var indexOfLastElement = this.people.Count - 1;
        this.people.RemoveAt(indexOfLastElement);
    }

    public IList<Person> Fetch()
    {
        return this.people;
    }

    public Person FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        var person = this.people.FirstOrDefault(p => p.Username.ToLower() == username.ToLower());
        if (person == null)
        {
            throw new InvalidOperationException("There is no user with this username.");
        }
        
        return person;
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var person = this.people.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new InvalidOperationException("There is no user with this id.");
        }

        return person;
    }
}