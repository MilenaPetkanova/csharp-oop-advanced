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
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IAirport airport = new Airport();
            IAirportController airportController = new AirportController(airport);
            IFlightController flightController = new FlightController(airport);

            var engine = new Engine(reader, writer, airportController, flightController);

            engine.Run();
        }
    }
}