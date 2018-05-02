namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RegisterSongCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public RegisterSongCommand(string[] args, IFestivalController festivalController)
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.RegisterSong(base.Arguments);
        }
    }
}
