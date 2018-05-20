namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RegisterSongCommand : BaseCommand
    {
        public RegisterSongCommand(string[] args, IFestivalController festivalController)
            : base(args, festivalController)
        {
        }

        public override string Execute()
        {
            return base.FestivalController.RegisterSong(base.Arguments);
        }
    }
}
