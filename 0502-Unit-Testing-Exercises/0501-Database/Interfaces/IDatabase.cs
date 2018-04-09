public interface IDatabase
{
    void Add(int number);

    void Remove();

    int[] Fetch();
}