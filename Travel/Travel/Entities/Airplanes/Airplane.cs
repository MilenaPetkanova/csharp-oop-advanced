namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private int seats;
        private int baggageCompartments;
        private readonly List<IPassenger> passengers;
        private readonly List<IBag> baggageCompartment;

        protected Airplane(int seats, int bags)
        {
            this.seats = seats;
            this.baggageCompartments = bags;
            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
        }

        public int Seats => this.seats;

        public int BaggageCompartments => this.baggageCompartments;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment;

        public bool IsOverbooked => this.Passengers.Count() > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var removedPassanger = this.passengers.ElementAt(seat);
            this.passengers.RemoveAt(seat);

            return removedPassanger;
        }
    }
}