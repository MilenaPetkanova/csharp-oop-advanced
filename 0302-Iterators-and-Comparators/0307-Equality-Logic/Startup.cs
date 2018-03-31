using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var sorted = new SortedSet<Person>();
        var hashed = new HashSet<Person>();

        var peopleCounter = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCounter; i++)
        {
            var args = Console.ReadLine().Split();
            var person = new Person(args[0], int.Parse(args[1]));
            sorted.Add(person);
            hashed.Add(person);
        }

        Console.WriteLine(sorted.Count);
        Console.WriteLine(hashed.Count);
    }
}
