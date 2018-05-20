using FestivalManager.Core.Controllers.Contracts;
using System;
using System.Linq;
using System.Reflection;

public class CommandFactory : ICommandFactory
{
    public ICommand CreateCommand(string[] arguments, IFestivalController festivalController, ISetController setController)
    {
        var assembly = Assembly.GetCallingAssembly();

        var commandName = arguments[0] + "Command";
        var type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName);

        var args = arguments.Skip(1)?.ToArray();

        ICommand command = (ICommand)Activator.CreateInstance(type, new object[] { args, festivalController });
        return command;
    }
}



