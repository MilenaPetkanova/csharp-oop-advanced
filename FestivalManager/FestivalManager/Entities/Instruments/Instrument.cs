namespace FestivalManager.Entities.Instruments
{
    using Contracts;
    using System;

    public abstract class Instrument : IInstrument
    {
        private const int MaxWear = 100;
        private const int MinWear = 0;

        private double wear;

        protected Instrument()
        {
            this.Wear = MaxWear;
        }

        public double Wear
        {
            get
            {
                return this.wear;
            }
            private set
            {
                this.wear = Math.Max(Math.Min(0, value), 100);
            }
        }

        protected abstract int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public bool IsBroken => this.Wear <= MinWear;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}
