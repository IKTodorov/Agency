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

namespace AgencyTests.TicketServiceTests
{
    public class UpdateTicketShould
    {
        [Fact]
        public async void UpdateTicketShould_Succeed() 
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new TicketDTO(1, 1, (decimal)23.5);
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TicketService(assertContext);
                await sut.UpdateTicket(expected);

                //assert
                var result = assertContext.Tickets.Find(expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.AdministrativeCosts, result.AdministrativeCosts);
                Assert.AreEqual(expected.JourneyId, result.JourneyId);

            }
        }

        [Fact]
        public async void UpdateTicketShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;
            var expected = new TicketDTO(5, 1, (decimal)23.5);


            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.UpdateTicket(expected));
            }
        }
    }
}
