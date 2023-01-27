using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace AgencyTests.AirplaneServiceTests
{
    public class GetAllAirplanesShould
    {
        [Fact]
        public async void GetAllAirplanesShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
            {
                new AirplaneDTO
                {
                    Id = 1,
                    HasFreeFood = false,
                    Vehicle = new VehicleDTO((decimal)30.7, 200)
                }
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new AirplaneService(assertContext);
                var result = (await sut.GetAllAirplanes()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].HasFreeFood, result[i].HasFreeFood);
                    Assert.AreEqual(expected[i].Vehicle.PricePerKilometer, result[i].Vehicle.PricePerKilometer);
                    Assert.AreEqual(expected[i].Vehicle.PassangerCapacity, result[i].Vehicle.PassangerCapacity);
                }
            }
        }
    }
}
