using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        List<Person> people = CreatePeople();

        var personIndex = int.Parse(Console.ReadLine());
        personIndex--;
        var personToCompareWith = people[personIndex];

        int equalPeopleCounter = 0;
        int notEqualPeopleCounter = 0;

        for (int i = 0; i < people.Count; i++)
        {
            if (people[i].CompareTo(personToCompareWith) == 0)
            {
                equalPeopleCounter++;
            }
            else
            {
                notEqualPeopleCounter++;
            }
        }

        if (equalPeopleCounter == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeopleCounter} {notEqualPeopleCounter} {people.Count}");
        }
    }

    private static List<Person> CreatePeople()
    {
        var people = new List<Person>();

        var input = Console.ReadLine();
        while (!input.Equals("END"))
        {
            var person = CreatePerson(input);
            people.Add(person);

            input = Console.ReadLine();
        }

        return people;
    }

    public static Person CreatePerson(string input)
    {
        var args = input.Split();
        var name = args[0];
        var age = int.Parse(args[1]);
        var town = args[2];

        var person = new Person(name, age, town);

        return person;
    }
}
