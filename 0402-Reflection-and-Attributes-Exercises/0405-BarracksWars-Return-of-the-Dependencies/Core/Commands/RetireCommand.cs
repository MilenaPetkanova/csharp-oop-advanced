namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using System;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            try
            {
                this.repository.RemoveUnit(unitType);
                string output = unitType + " retired!";
                return output;
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
        }
    }
}
