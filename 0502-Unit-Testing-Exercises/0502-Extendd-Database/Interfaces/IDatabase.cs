using System.Collections.Generic;

public interface IDatabase
{
    void Add(Person person);

    void Remove();

    IList<Person> Fetch();

    Person FindByUsername(string username);

    Person FindById(long id);
}