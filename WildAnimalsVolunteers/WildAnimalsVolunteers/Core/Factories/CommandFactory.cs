namespace WildAnimalsVolunteers.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WildAnimalsVolunteers.Interfaces;

    public class CommandFactory : ICommandFactory
    {
        public IExecutable CreateCommand(string commandName, IList<string> commandArgs, IVolunteersController volunteersController)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var commandType = assembly.GetTypes().FirstOrDefault(c => c.Name.Equals(commandName + "Command"));

            ValidateCommand(commandType);

            var commandCtor = new object[] { commandArgs, volunteersController };
            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, commandCtor);

            return command;
        }

        private static void ValidateCommand(Type commandType)
        {
            if (commandType == null)
            {
                throw new ArgumentException("This command is not found!");
            }
            else if (!commandType.IsAssignableFrom(typeof(IExecutable)))
            {
                throw new InvalidOperationException("This command is not assignable from IExecutable!");

            }
        }
    }
}