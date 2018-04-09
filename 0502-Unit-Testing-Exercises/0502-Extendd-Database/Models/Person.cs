public class Person : IPerson
{
    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id { get; set; }

    public string Username { get; set; }
}

