using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AgencyTests.JourneyServiceTests
{
    public class DeleteJourneyShould
    {
        [Fact]
        public async void DeleteJourneyShould_Succeed()
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
                await sut.DeleteJourney(1);
                //assert
                var tickets = assertContext.Tickets.Where(x => x.JourneyId == 1).ToArray();
                Assert.AreEqual(tickets.Length, 0);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetJourney(1));
            }

        }
        [Fact]
        public async void DeleteJourneyShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.DeleteJourney(5));
            }
        }


    }
}
