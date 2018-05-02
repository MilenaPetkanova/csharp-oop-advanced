namespace Travel
{
    using Core;
    using Core.Controllers;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Travel.Entities.Contracts;
    using Travel.Core.Controllers.Contracts;
    using System.Collections.Generic;
    using Travel.Entities.Items.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Airplanes;

    public class StartUp
    {
        public static void Main()
        {
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //IAirport airport = new Airport();
            //IAirportController airportController = new AirportController(airport);
            //IFlightController flightController = new FlightController(airport);

            //var engine = new Engine(reader, writer, airportController, flightController);

            //engine.Run();

           // var airport = new Airport();

           // var passenger1 = new Passenger("TestPassenger1");
           // var passenger2 = new Passenger("TestPassenger2");
           // var passenger3 = new Passenger("TestPassenger3");
           // var passenger4 = new Passenger("TestPassenger4");
           // var passenger5 = new Passenger("TestPassenger5");
           // var passenger6 = new Passenger("TestPassenger6");

           // airport.AddPassenger(passenger1);
           // airport.AddPassenger(passenger2);
           // airport.AddPassenger(passenger3);
           // airport.AddPassenger(passenger4);
           // airport.AddPassenger(passenger5);
           // airport.AddPassenger(passenger6);

           // var items = new List<IItem> { new Jewelery(), new Laptop(), new CellPhone() };
           // var bag1 = new Bag(passenger1, items);

           // airport.AddCheckedBag(bag1);

           // var airplane = new LightAirplane();
           // airplane.AddPassenger(passenger1);
           // airplane.AddPassenger(passenger2);
           // airplane.AddPassenger(passenger3);
           // airplane.AddPassenger(passenger4);
           // airplane.AddPassenger(passenger5);
           // airplane.AddPassenger(passenger6);

            
           // var trip1 = new Trip("Sofia", "Vidin", airplane);

           // airport.AddTrip(trip1);

           //var flightController = new FlightController(airport);

           // //flightController.TakeOff();

            //System.Console.WriteLine(flightController.TakeOff());

             var airport = new Airport();

            var passenger1 = new Passenger("TestPassenger1");

            airport.AddPassenger(passenger1);

            var items = new List<IItem> { new Jewelery(), new Laptop(), new CellPhone() };
            var bag1 = new Bag(passenger1, items);

            airport.AddCheckedBag(bag1);

            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger1);

            var trip1 = new Trip("Sofia", "Vidin", airplane);
            //var trip2 = new Trip("Sofia", "Montana", new LightAirplane());

            airport.AddTrip(trip1);
            //airport.AddTrip(trip2);

            var flightController = new FlightController(airport);

            System.Console.WriteLine(flightController.TakeOff());
        }
    }
}