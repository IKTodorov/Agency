using AgencyData.DBContext;
using AgencyData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgencyTests
{
    public class Utils
    {
        public static DbContextOptions<AgencyContext> GetOptions(string nameOfDb)
        {
            return new DbContextOptionsBuilder<AgencyContext>()
                .UseInMemoryDatabase(databaseName: nameOfDb)
                .Options;
        }

        public static void Seed(AgencyContext context)
        {
            var vehicles = new[]
            {
                new Vehicle
                {
                    Id = 1,
                    PricePerKilometer = (decimal)12.3,
                    PassangerCapacity = 100
                },
                new Vehicle
                {
                    Id = 2,
                    PricePerKilometer = (decimal)1.3,
                    PassangerCapacity = 1000
                },
                new Vehicle
                {
                    Id = 3,
                    PricePerKilometer = (decimal)30.7,
                    PassangerCapacity = 200
                }

            };

            var bus = new Bus
            {
                Id = 1,
                VehicleId = 1
            };

            var train = new Train
            {
                Id = 1,
                Carts = 10,
                VehicleId = 2
            };

            var airplane = new Airplane
            {
                Id = 1,
                HasFreeFood = false,
                VehicleId = 3
            };

            var journeys = new[]
            {
                new Journey
                {
                    Id = 1,
                    StartLocation = "Bulgaria",
                    Destination = "Turkey",
                    Distance = 800,
                    VehicleId = 3
                },
                new Journey
                {
                    Id = 2,
                    StartLocation = "Turkey",
                    Destination = "Greece",
                    Distance = 400,
                    VehicleId = 1
                },
                new Journey
                {
                    Id = 3,
                    StartLocation = "Sofia",
                    Destination = "Burgas",
                    Distance = 380,
                    VehicleId = 2
                }
            };

            var tickets = new[]
            {
                new Ticket
                {
                    Id = 1,
                    AdministrativeCosts = (decimal)23.5,
                    JourneyId = 1
                },
                new Ticket
                {
                    Id = 2,
                    AdministrativeCosts = (decimal)18.7,
                    JourneyId = 2
                },
                new Ticket
                {
                    Id = 3,
                    AdministrativeCosts = (decimal)2.5,
                    JourneyId = 3
                }
            };

            context.Vehicles.AddRange(vehicles);
            context.Airplanes.Add(airplane);
            context.Buses.Add(bus);
            context.Trains.Add(train);
            context.Journeys.AddRange(journeys);
            context.Tickets.AddRange(tickets);

            context.SaveChanges();
        }
    }
}
