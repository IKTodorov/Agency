using AgencyData.Models;
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
        public async Task<IActionResult> CreateTrain(TrainDTO trainDTO)
        {
            await _trainService.CreateTrain(trainDTO);
            return new JsonResult(Ok());
        }
        [HttpGet]
        public async Task<IActionResult> GetTrain(int id) 
        {
            var train = await _trainService.GetTrain(id);

            if(train== null)
            {
                return new JsonResult(NotFound("No train with id " + id)); 
            }
            return new JsonResult(Ok(train));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTrains() 
        { 
            var trains = await _trainService.GetAllTrains();
            if (!trains.Any())
            {
                return new JsonResult(NotFound("No trains found"));
            }
            return new JsonResult(Ok(trains));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            await _trainService.DeleteTrain(id);
            return new JsonResult(Ok());
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateTrain(TrainDTO trainDTO)
        {
            await _trainService.UpdateTrain(trainDTO);
            return new JsonResult(Ok());
        }
    }
}
