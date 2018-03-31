using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var listyIterator = CreateListyIterator();
        
        var command = Console.ReadLine();
        while (!command.Equals("END"))
        {
            ProceedCommand(command, listyIterator);
            command = Console.ReadLine();
        }
    }

    private static ListyIterator<string> CreateListyIterator()
    {
        var command = Console.ReadLine();
        var elements = command.Split().Skip(1).ToArray();
        var listyIterator = new ListyIterator<string>(elements);

        return listyIterator;
    }

    private static void ProceedCommand(string command, ListyIterator<string> listyIterator)
    {
        var commandArgs = command.Split();
        var commandName = commandArgs[0];

        switch (commandName)
        {
            case "Move":
                Console.WriteLine(listyIterator.Move());
                break;
            case "HasNext":
                Console.WriteLine(listyIterator.HasNext());
                break;
            case "Print":
                try
                {
                    listyIterator.Print();
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                break;
        }
    }
}
