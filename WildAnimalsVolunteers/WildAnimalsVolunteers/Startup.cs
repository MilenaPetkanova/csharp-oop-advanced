using WildAnimalsVolunteers.Core;
using WildAnimalsVolunteers.Interfaces;

class Startup
{
    static void Main()
    {
        IInputReader consoleReader = new ConsoleLineReader();
        IOutputWriter consoleWriter = new ConsoleLineWriter();
        IVolunteersController volunteersController = new VolunteersController(); ;

        var engine = new Engine(consoleReader, consoleWriter, volunteersController);
        engine.Run();
    }
}
