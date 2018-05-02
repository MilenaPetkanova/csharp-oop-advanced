namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class SignUpPerformerCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public SignUpPerformerCommand(string[] args, IFestivalController festivalController)
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.SignUpPerformer(base.Arguments);
        }
    }
}
