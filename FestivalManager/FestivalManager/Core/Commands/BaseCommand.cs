namespace FestivalManager.Core.Commands
{
    using System.Collections.Generic;

    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(string[] args)
        {
            this.Arguments = args;
        }

        public string[] Arguments { get; }

        public abstract string Execute();
    }
}
