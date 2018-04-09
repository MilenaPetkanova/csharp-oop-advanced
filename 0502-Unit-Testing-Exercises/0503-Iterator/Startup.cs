using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var args = Console.ReadLine().Split().Skip(1).ToList();
        var listIterator = new ListIterator(args);

        var command = Console.ReadLine();
        while (!command.Equals("END"))
        {
            try
            {
                ProceedCommand(listIterator, command);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch(ArgumentNullException ane)
            {
                Console.WriteLine(ane);
            }

            command = Console.ReadLine();
        }
    }

    private static void ProceedCommand(ListIterator listIterator, string command)
    {
        switch (command)
        {
            case "HasNext":
                Console.WriteLine(listIterator.HasNext());
                break;
            case "Move":
                Console.WriteLine(listIterator.Move());
                break;
            case "Print":
                listIterator.Print();
                break;
        }
    }
}
