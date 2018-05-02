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
        var type = assembly.GetTypes()
            .FirstOrDefault(t => t.Name == commandName);

        var args = arguments.Skip(1)?.ToArray();

        if (commandName == "LetsRockCommand")
        {
            ICommand letsRock = (ICommand)Activator.CreateInstance(type, new object[] { args, setController });
            return letsRock;
        }

        ICommand command = (ICommand)Activator.CreateInstance(type, new object[] { args, festivalController });
        return command;
    }
}

//var commandName = tokens.First() + "Command";
//var commandArgs = tokens.Skip(1).ToArray();

//var assembly = Assembly.GetCallingAssembly();
//var commandType = assembly.GetTypes()
//    .FirstOrDefault(c => c.Name.Equals(commandName));

//var ctor = commandType.GetConstructors().First();
//var ctorParams = ctor.GetParameters();
//var parameters = new object[ctorParams.Length];

//for (int i = 0; i < parameters.Length; i++)
//{
//    var paramType = ctorParams[i].ParameterType;

//    if (paramType == typeof(IList<string>))
//    {
//        parameters[i] = commandArgs;
//    }
//    else
//    {
//        var paramInfo = this.GetType().GetProperties()
//            .FirstOrDefault(p => p.PropertyType == paramType);
//        parameters[i] = paramInfo.GetValue(this);
//    }
//}

//var parameters = new object[] { commandArgs, this.festivalController };
//var command = (ICommand)Activator.CreateInstance(commandType, parameters);

