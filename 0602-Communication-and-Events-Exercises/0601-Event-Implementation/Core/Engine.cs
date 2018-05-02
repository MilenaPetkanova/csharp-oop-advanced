using System;

public class Engine
{
    IReader reader;
    IWriter writer;

    public Engine()
    {
        this.reader = new ConsoleReader();
        this.writer = new ConsoleWriter(); 
    }

    public void Run()
    {
        var dispatcher = new Dispatcher();
        var handler = new Handler();
        dispatcher.NameChange += handler.OnDispatcherNameChange;

        var name = reader.ReadLine();
        while (!name.Equals("End"))
        {
            dispatcher.Name = name;

            name = reader.ReadLine();
        }
    }
}
