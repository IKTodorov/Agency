using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace AgencyTests.BusServiceTests
{
    public class CreateBusShould
    {
        [Fact]
        public async void CreateBusShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BusDTO(2, new VehicleDTO((decimal)23.4, 180));

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new BusService(assertContext);
                await sut.CreateBus(expected);

                //assert
                var result = assertContext.Buses.Find(expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);

            }
        }
    }
}
