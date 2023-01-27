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

namespace AgencyTests.AirplaneServiceTests
{
    public class UpdateAirplaneShould
    {
        [Fact]
        public async void UpdateAirplaneShould_Succeed() 
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new AirplaneDTO
            {
                Id = 1,
                HasFreeFood = true,
                Vehicle = new VehicleDTO((decimal)23.4, 180)
            };
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new AirplaneService(assertContext);
                await sut.UpdateAirplane(expected);

                //assert
                var result = assertContext.Airplanes.Find(expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.HasFreeFood, result.HasFreeFood);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);

            }
        }

        [Fact]
        public async void UpdateAirplaneShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;
            var expected = new AirplaneDTO
            {
                Id = 2,
                HasFreeFood = true,
                Vehicle = new VehicleDTO((decimal)23.4, 180)
            };

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.UpdateAirplane(expected));
            }
        }
    }
}
