using AgencyServices.Contracts;
using AgencyServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        public AirplaneController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirplane(int id)
        {
            var airplane = await _airplaneService.GetAirplane(id);
            if(airplane == null)
            {
                return new JsonResult(NotFound("No airplane with id "+id));
            }
            return new JsonResult(Ok(airplane));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAirplane(AirplaneDTO airplaneDTO)
        {
            await _airplaneService.CreateAirplane(airplaneDTO);
            return new JsonResult(Ok());
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAirplanes()
        {
            var airplanes = await _airplaneService.GetAllAirplanes();
            if(!airplanes.Any())
            {
                return new JsonResult(NotFound("No airplanes found"));
            }
            return new JsonResult(Ok(airplanes));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAirplane(int id) 
        {
            await _airplaneService.DeleteAirplane(id);
           
            return new JsonResult(Ok());
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAirplane(AirplaneDTO airplaneDTO)
        {
            await _airplaneService.UpdateAirplane(airplaneDTO);
            
            return new JsonResult(Ok());
        }

    }
}
