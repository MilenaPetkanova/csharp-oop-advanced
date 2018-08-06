using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter consoleWriter;
    private readonly IWriter fileWriter;
    private readonly IManager commandManager;
    private const string Command = "Command";
    private const string EndCommand = "End";

    public Engine(IReader reader, IWriter consoleWriter, IWriter fileWriter, IManager commandManager)
    {
        this.reader = reader;
        this.consoleWriter = consoleWriter;
        this.fileWriter = fileWriter;
        this.commandManager = commandManager;
    }

    public void Run()
    {
        var line = reader.ReadLine();

        while (!line.Equals(EndCommand))
        {
            IList<string> arguments = line.Split().ToList();
            this.consoleWriter.WriteLine(this.processInput(arguments));
            line = reader.ReadLine();
        }
    }

    private string processInput(IList<string> arguments)
    {
        var command = arguments[0];
        arguments.RemoveAt(0);

        var sb = new StringBuilder();

        var commandType = Type.GetType(command + Command);
        var constructor = commandType.GetConstructor(new Type[] {typeof(IList<string>), typeof(IManager)});
        var cmd = (ICommand) constructor.Invoke(new object[] {arguments, commandManager});
        var content = sb.AppendLine(cmd.Execute());
        this.fileWriter.WriteLine(content.ToString());
        return cmd.Execute();
    }
}