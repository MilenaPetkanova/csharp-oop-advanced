namespace FestivalManager.Core.Commands
{
    using FestivalManager.Core.Controllers.Contracts;

    public class RegisterSetCommand : BaseCommand
    {
        private IFestivalController festivalController;

        public RegisterSetCommand(string[] args, IFestivalController festivalController) 
            : base(args)
        {
            this.festivalController = festivalController;
        }

        public override string Execute()
        {
            return this.festivalController.RegisterSet(base.Arguments);
        }
    }
}
