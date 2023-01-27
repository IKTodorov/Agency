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

namespace AgencyTests.TrainServiceTests
{
    public class GetTrainShould
    {
        [Fact]
        public async void GetTrainShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new TrainDTO(1, 10, new VehicleDTO((decimal)1.3, 1000));

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TrainService(assertContext);
                var result = await sut.GetTrain(1);
                //assert
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Carts, result.Carts);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);
            }

        }
        [Fact]
        public async void GetTrainShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetTrain(5));
            }
        }

    }
}
