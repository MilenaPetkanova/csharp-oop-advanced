namespace Travel.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private IAirport airport;
        private IAirplaneFactory airplaneFactory;
        private IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        public string RegisterPassenger(string username)
        {
            var alreadyRegistered = this.airport.Passengers.Any(p => p.Username.Equals(username));
            if (alreadyRegistered)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            var passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            var passenger = this.airport.GetPassenger(username);

            var items = new List<IItem>();

            foreach (var itemName in bagItems)
            {
                var item = this.itemFactory.CreateItem(itemName);
                items.Add(item);
            }

            var bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }

        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = this.airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            var passenger = this.airport.GetPassenger(username);
            var trip = this.airport.GetTrip(tripId);

            var checkedIn = trip.Airplane.Passengers.Any(p => p.Username == username);
            if (checkedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            var confiscatedBags = 0;
            foreach (var index in bagIndices)
            {
                if (index < passenger.Bags.Count)
                {
                    var bagToCheckIn = passenger.Bags[index];

                    if (bagToCheckIn.Items.Sum(i => i.Value) > BagValueConfiscationThreshold)
                    {
                        this.airport.AddConfiscatedBag(bagToCheckIn);
                        confiscatedBags++;
                    }
                    else 
                    {
                        this.airport.AddCheckedBag(bagToCheckIn);
                    }

                    passenger.Bags.RemoveAt(index);
                }
            }

            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";

        }
    }
}