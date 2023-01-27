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

namespace AgencyTests.TrainServiceTests
{
    public class UpdateTrainShould
    {
        [Fact]
        public async void UpdateTrainShould_Succeed() 
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new TrainDTO(1, 12, new VehicleDTO((decimal)30.3, 150));
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TrainService(assertContext);
                await sut.UpdateTrain(expected);

                //assert
                var result = assertContext.Trains.Find(expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Carts, result.Carts);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);

            }
        }

        [Fact]
        public async void UpdateTrainShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;
            var expected = new TrainDTO(2, 12, new VehicleDTO((decimal)23.4, 180));

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.UpdateTrain(expected));
            }
        }
    }
}
