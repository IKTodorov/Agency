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

namespace AgencyTests.AirplaneServiceTests
{
    public class GetAirplaneShould
    {
        [Fact]
        public async void GetAirplaneShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new AirplaneDTO
            {
                Id = 1,
                HasFreeFood = false,
                Vehicle = new VehicleDTO((decimal)30.7, 200)      
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new AirplaneService(assertContext);
                var result = await sut.GetAirplane(1);
                //assert
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.HasFreeFood, result.HasFreeFood);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);
            }

        }
        [Fact]
        public async void GetAirplaneShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetAirplane(5));
            }
        }

    }
}
