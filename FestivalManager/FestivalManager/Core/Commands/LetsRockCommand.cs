namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class LetsRockCommand : BaseCommand
    {
        private ISetController setController;

        public LetsRockCommand(string[] args, ISetController setController)
            : base(args)
        {
            this.setController = setController;
        }

        public override string Execute()
        {
            return this.setController.PerformSets();
        }
    }
}
