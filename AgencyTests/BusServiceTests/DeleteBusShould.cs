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

namespace AgencyTests.BusServiceTests
{
    public class DeleteBusShould
    {
        [Fact]
        public async void DeleteBusShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new BusDTO(1, new VehicleDTO((decimal)12.3, 100));

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new BusService(assertContext);
                await sut.DeleteBus(1);
                //assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetBus(1));
            }

        }
        [Fact]
        public async void DeleteBusShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.DeleteBus(5));
            }
        }

    }
}
