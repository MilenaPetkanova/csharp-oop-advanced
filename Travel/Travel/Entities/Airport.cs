﻿namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;

    public class Airport : IAirport
	{
		private readonly List<IBag> checkedInBags;
        private readonly List<IBag> confiscatedBags;
        private readonly List<IPassenger> passengers;
        private readonly List<ITrip> trips;

        public Airport()
        {
            this.checkedInBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>();
            this.passengers = new List<IPassenger>();
            this.trips = new List<ITrip>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags;

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

        public IReadOnlyCollection<ITrip> Trips => this.trips;

        public void AddCheckedBag(IBag bag)
        {
            this.checkedInBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.confiscatedBags.Add(bag);
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public IPassenger GetPassenger(string username)
        {
            IPassenger passenger = this.passengers.FirstOrDefault(p => p.Username.Equals(username));

            if (passenger == null)
            {
                throw new ArgumentException("No such passanger!");
            }

            return passenger;
        }

        public ITrip GetTrip(string id)
        {
            ITrip trip = this.trips.FirstOrDefault(t => t.Id.Equals(id));

            if (trip == null)
            {
                throw new ArgumentException("No such id!");
            }

            return trip;
        }
    }
}