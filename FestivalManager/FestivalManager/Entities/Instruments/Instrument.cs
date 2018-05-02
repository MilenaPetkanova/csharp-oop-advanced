using System;

namespace FestivalManager.Entities.Instruments
{
    using Contracts;

    public abstract class Instrument : IInstrument
    {
        private const int MaxWear = 100;
        private const int MinWear = 0;

        private double wear;

        protected Instrument(int repairAmount)
        {
            this.Wear = MaxWear;
            this.RepairAmount = repairAmount;
        }

        public double Wear
        {
            get
            {
                return this.wear;
            }
            private set
            {
                if (value < MinWear)
                {
                    this.wear = MinWear;
                }
                else if (value > MaxWear)
                {
                    this.wear = MaxWear;
                }
                else
                {
                    this.wear = value;
                }

            }
        }

        protected int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public bool IsBroken => this.Wear <= 0;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}
