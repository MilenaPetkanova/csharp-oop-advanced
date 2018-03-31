using System.Collections;
using System.Collections.Generic;

public class People : IEnumerable<Person>
{
    private NameComparator nameComparator;
    private SortedSet<Person> peopleByName;
    private AgeComparator ageComparator;
    private SortedSet<Person> peopleByAge;

    public People(params Person[] people)
    {
        this.nameComparator = new NameComparator();
        this.peopleByName = new SortedSet<Person>(people, nameComparator);
        this.ageComparator = new AgeComparator();
        this.peopleByAge = new SortedSet<Person>(people, ageComparator);
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in peopleByName)
        {
            yield return person;
        }
        foreach (var person in peopleByAge)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
    private class NameComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
            if (result == 0)
            {
                var firstFirstLetter = char.ToLower(firstPerson.Name[0]);
                var secondFirstLetter = char.ToLower(secondPerson.Name[0]);

                result = firstFirstLetter.CompareTo(secondFirstLetter);
            }

            return result;
        }
    }

    private class AgeComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var result = firstPerson.Age.CompareTo(secondPerson.Age);
            return result;
        }
    }
}