using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace AgencyTests.BusServiceTests
{
    public class GetAllBusesShould
    {
        [Fact]
        public async void GetAllBusesShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
            {
                new BusDTO(1, new VehicleDTO((decimal)12.3, 100))
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new BusService(assertContext);
                var result = (await sut.GetAllBuses()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Vehicle.PricePerKilometer, result[i].Vehicle.PricePerKilometer);
                    Assert.AreEqual(expected[i].Vehicle.PassangerCapacity, result[i].Vehicle.PassangerCapacity);
                }
            }
        }
    }
}
