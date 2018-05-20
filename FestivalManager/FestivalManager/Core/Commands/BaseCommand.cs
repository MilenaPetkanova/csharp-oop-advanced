namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;
    using System.Collections.Generic;

    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(string[] args, IFestivalController festivalController)
        {
            this.Arguments = args;
            this.FestivalController = festivalController;
        }

        protected string[] Arguments { get; }

        protected IFestivalController FestivalController { get; }   
        
        public abstract string Execute();
    }
}
