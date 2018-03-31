using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var people = new List<Person>();

        var peopleCounter = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCounter; i++)
        {
            var args = Console.ReadLine().Split();
            var person = new Person(args[0], int.Parse(args[1]));
            people.Add(person);
        }

        var customPeopleCollection = new People(people.ToArray());

        foreach (var person in customPeopleCollection)
        {
            Console.WriteLine(person);
        }
    }
}
