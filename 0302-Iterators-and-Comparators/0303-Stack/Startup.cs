using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var myStack = new Stack<int>();

        var command = Console.ReadLine();
        while (!command.Equals("END"))
        {
            ProceedCommand(command, myStack);
            command = Console.ReadLine();
        }

        PrintStack(myStack);
        PrintStack(myStack);
    }

    private static void PrintStack(Stack<int> myStack)
    {
        foreach (var element in myStack)
        {
            Console.WriteLine(element);
        }
    }

    private static void ProceedCommand(string command, Stack<int> myStack)
    {
        var commandArgs = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        var commandName = commandArgs.First();

        switch (commandName)
        {
            case "Push":
                var args = commandArgs.Skip(1).Select(int.Parse).ToArray();
                myStack.Push(args);
                break;
            case "Pop":
                try
                {
                    myStack.Pop();
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                break;
        }
    }
}
