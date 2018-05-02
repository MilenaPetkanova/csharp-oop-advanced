namespace WildAnimalsVolunteers.Commands
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public abstract class BaseCommand : IExecutable
    {
        public BaseCommand(IList<string> commandArgs, IVolunteersController volunteersController)
        {
            this.CommandArgs = commandArgs;
            this.VolunteersController = volunteersController;
        }

        public IList<string> CommandArgs { get; }

        public IVolunteersController VolunteersController { get; }

        public abstract string Execute();
    }
}
