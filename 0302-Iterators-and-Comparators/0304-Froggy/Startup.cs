using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var stones = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        var lakeCollection = new Lake<int>(stones);

        Console.WriteLine(string.Join(", ", lakeCollection));
    }
}
