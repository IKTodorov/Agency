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
    public class DeleteTicketShould
    {
        [Fact]
        public async void DeleteTicketShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new TicketDTO(4, 3, (decimal)12.3);

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TicketService(assertContext);
                await sut.DeleteTicket(1);
                //assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetTicket(1));
            }

        }
        [Fact]
        public async void DeleteTicketShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.DeleteTicket(5));
            }
        }

    }
}
