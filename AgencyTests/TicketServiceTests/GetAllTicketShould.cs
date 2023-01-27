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


namespace AgencyTests.TicketServiceTests
{
    public class GetAllTicketsShould
    {
        [Fact]
        public async void GetAllTicketsShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
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

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TicketService(assertContext);
                var result = (await sut.GetAllTickets()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].AdministrativeCosts, result[i].AdministrativeCosts);
                    Assert.AreEqual(expected[i].JourneyId, result[i].JourneyId);
                }
            }
        }
    }
}
