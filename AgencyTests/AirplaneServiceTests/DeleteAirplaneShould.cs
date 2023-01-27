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
    public class DeleteAirplaneShould
    {
        [Fact]
        public async void DeleteAirplaneShould_Succeed()
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
                await sut.DeleteAirplane(1);
                //assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetAirplane(1));
            }

        }
        [Fact]
        public async void DeleteAirplaneShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.DeleteAirplane(5));
            }
        }

    }
}
