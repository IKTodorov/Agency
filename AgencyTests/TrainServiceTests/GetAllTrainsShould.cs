using AgencyData.DBContext;
using AgencyServices.DTOs;
using AgencyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace AgencyTests.TrainServiceTests
{
    public class GetAllTrainsShould
    {
        [Fact]
        public async void GetAllTrainsShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
            {
                new TrainDTO(1, 10, new VehicleDTO((decimal)1.3, 1000))
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new TrainService(assertContext);
                var result = (await sut.GetAllTrains()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Carts, result[i].Carts);
                    Assert.AreEqual(expected[i].Vehicle.PricePerKilometer, result[i].Vehicle.PricePerKilometer);
                    Assert.AreEqual(expected[i].Vehicle.PassangerCapacity, result[i].Vehicle.PassangerCapacity);
                }
            }
        }
    }
}
