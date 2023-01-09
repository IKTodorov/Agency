using AgencyServices.Contracts;
using AgencyServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpPost]
        public JsonResult CreateTrain(TrainDTO trainDTO)
        {
            var train_result = _trainService.CreateTrain(trainDTO);
            return new JsonResult(Ok(train_result));
        }
    }
}
