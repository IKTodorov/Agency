using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using AgencyTests.VehicleServiceTests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AgencyTests.JourneyServiceTests
{
    public class GetJourneyShould
    {
        [Fact]
        public async void GetJourneyShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new JourneyDTO(1, 3, "Bulgaria", "Turkey", 800);

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new JourneyService(assertContext);
                var result = await sut.GetJourney(1);
                //assert
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.VehicleId, result.VehicleId);
                Assert.AreEqual(expected.Destination, result.Destination);
                Assert.AreEqual(expected.StartLocation, result.StartLocation);
                Assert.AreEqual(expected.Distance, result.Distance);
            }

        }
        [Fact]
        public async void GetJourneyShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetJourney(5));
            }
        }

    }
}
