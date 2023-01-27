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
    public class DeleteTrainShould
    {
        [Fact]
        public async void DeleteTrainShould_Succeed()
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
                await sut.DeleteTrain(1);
                //assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.GetTrain(1));
            }

        }
        [Fact]
        public async void DeleteTrainShould_Throw()
        {
            //arrange
            var nameOfDb = new StackTrace().GetFrame(0).GetMethod().Name;

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);
                //act & assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.DeleteTrain(5));
            }
        }

    }
}
