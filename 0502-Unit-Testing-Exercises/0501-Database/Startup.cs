class Startup
{
    static void Main(string[] args)
    {
        var database = new Database(new int[1] { 9 });
        int[] result = database.Fetch();
        bool test = result.Equals(database.Numbers);
    }
}

