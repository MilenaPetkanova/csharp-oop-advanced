namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class AddSongToSetCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public AddSongToSetCommand(string[] args, IFestivalController festivalController)
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.AddSongToSet(base.Arguments);
        }
    }
}
