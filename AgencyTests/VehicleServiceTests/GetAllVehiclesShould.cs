using AgencyData.DBContext;
using AgencyData.Models;
using AgencyServices.DTOs;
using AgencyServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AgencyTests.VehicleServiceTests
{
    public class GetAllVehiclesShould
    {
        [Fact]
        public async void GetAllVehiclesShould_Succeed()
        {
            //arrange
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
            {
                new VehicleDTO((decimal)12.3, 100),
                new VehicleDTO((decimal)1.3, 1000),
                new VehicleDTO((decimal)30.7, 200)
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                //act
                var sut = new VehicleService(arrangeContext);
                var result = (await sut.GetAllVehicles()).ToArray();

                //assert
                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].PricePerKilometer, result[i].PricePerKilometer);
                    Assert.AreEqual(expected[i].PassangerCapacity, result[i].PassangerCapacity);
                }
            }
        }

    }
}
