using AgencyServices.Contracts;
using AgencyServices.Services;
using AgencyServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgencyData.Models;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _service;

        public JourneyController(IJourneyService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJoureny(JourneyDTO journeyDTO)
        {
            await _service.CreateJourney(journeyDTO);
            
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJourney(int id)
        {
            await _service.DeleteJourney(id);
            
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetJourney(int id)
        {
            JourneyDTO journey = await _service.GetJourney(id);
            if (journey == null)
            {
                return new JsonResult(NotFound("No journey with id " + id));
            }
            return Ok(journey);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllJourneys()
        {
            var journeys = await _service.GetAllJourneys();
            if (!journeys.Any())
            {
                return new JsonResult(NotFound("No journeys found"));
            }
            return Ok(journeys);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateJourney(JourneyDTO journeyDTO)
        {
            await _service.UpdateJourney(journeyDTO);
            return new JsonResult(Ok());
        }
    }
}
