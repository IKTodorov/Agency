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


namespace AgencyTests.TrainServiceTests
{
    public class CreateTrainShould
    {
        [Fact]
        public async void CreateTrainShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new TrainDTO(2, 12, new VehicleDTO((decimal)23.4, 180));

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TrainService(assertContext);
                await sut.CreateTrain(expected);

                //assert
                var result = assertContext.Trains.Find(expected.Id);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Carts, result.Carts);
                Assert.AreEqual(expected.Vehicle.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.Vehicle.PassangerCapacity, result.Vehicle.PassangerCapacity);

            }
        }
    }
}
