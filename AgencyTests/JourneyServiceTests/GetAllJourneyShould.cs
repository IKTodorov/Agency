using AgencyData.DBContext;
using AgencyData.Models;
using AgencyServices.DTOs;
using AgencyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace AgencyTests.JourneyServiceTests
{
    public class GetAllJourneysShould
    {
        [Fact]
        public async void GetAllJourneysShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
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

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new JourneyService(assertContext);
                var result = (await sut.GetAllJourneys()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].VehicleId, result[i].VehicleId);
                    Assert.AreEqual(expected[i].Destination, result[i].Destination);
                    Assert.AreEqual(expected[i].StartLocation, result[i].StartLocation);
                    Assert.AreEqual(expected[i].Distance, result[i].Distance);
                }
            }
        }
    }
}
