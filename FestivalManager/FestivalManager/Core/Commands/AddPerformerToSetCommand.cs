namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class AddPerformerToSetCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public AddPerformerToSetCommand(string[] args, IFestivalController festivalController)
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.AddPerformerToSet(base.Arguments);
        }
    }
}
