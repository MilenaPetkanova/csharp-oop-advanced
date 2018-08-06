
namespace SimpleFinanceManager
{
    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter();
            IManager manager = new CommandManager();

            var engine = new Engine(reader, consoleWriter, fileWriter, manager);
            engine.Run();
        }
    }
}