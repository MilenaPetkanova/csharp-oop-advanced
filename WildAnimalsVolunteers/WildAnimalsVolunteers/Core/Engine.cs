namespace WildAnimalsVolunteers.Core
{
    using System;
    using System.Linq;
    using WildAnimalsVolunteers.Interfaces;

    public class Engine : IRunnable
    {
        private const string EndCommand = "End";
        private const string Deliminator = " -> ";

        private readonly IInputReader consoleReader;
        private readonly IOutputWriter consoleWriter;
        private readonly IVolunteersController volunteersController;
        private readonly ICommandFactory commandFactory;
        private bool isRunning;

        public Engine(IInputReader consoleReader, IOutputWriter consoleWriter, IVolunteersController volunteersController)
        {
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
            this.volunteersController = volunteersController;
            this.commandFactory = new CommandFactory();
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (isRunning)
            {
                var inputLine = this.consoleReader.ReadLine();

                this.ProcessCommand(inputLine);
            }
        }

        private void ProcessCommand(string inputLine)
        {
            var args = inputLine.Split(Deliminator, StringSplitOptions.RemoveEmptyEntries);

            var commandName = args[0];
            if (commandName.Equals(EndCommand))
            {
                this.isRunning = false;
                return;
            }

            try
            {
                var commandArgs = args.Skip(1).ToList();
                IExecutable command = this.commandFactory.CreateCommand(commandName, commandArgs, this.volunteersController);
                var commandOutput = command.Execute();

                this.consoleWriter.WriteLine(commandOutput);
            }
            catch (Exception e)
            {
                this.consoleWriter.WriteLine(e.Message);
            }

        }
    }
}
