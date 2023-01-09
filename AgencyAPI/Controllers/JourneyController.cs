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
        public JsonResult CreateJoureny(JourneyDTO journeyDTO)
        {
            var journey_result = _service.CreateJourney(journeyDTO);
            if(journey_result == null)
            {
                return new JsonResult(BadRequest("No such vehicle with id "+journeyDTO.VehicleId));
            }
            return new JsonResult(Ok(journeyDTO));
        }

        [HttpDelete]
        public JsonResult DeleteJourney(int id)
        {
            JourneyDTO journey = _service.DeleteJourney(id);
            if (journey == null)
            {
                return new JsonResult(NotFound("No journey with id "+id));
            }
            return new JsonResult(Ok(journey));
        }
        [HttpGet]
        public JsonResult GetJourney(int id)
        {
            JourneyDTO journey = _service.GetJourney(id);
            if (journey == null)
            {
                return new JsonResult(NotFound("No journey with id " + id));
            }
            return new JsonResult(Ok(journey));
        }
        [HttpGet("GetAll")]
        public JsonResult GetAllJourneys()
        {
            List<JourneyDTO> journeys = _service.GetAllJourneys();
            if (journeys == null)
            {
                return new JsonResult(NotFound("No journeys found"));
            }
            return new JsonResult(Ok(journeys));
        }
    }
}
