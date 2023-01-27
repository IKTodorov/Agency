using AgencyServices.Contracts;
using AgencyServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBus(BusDTO busDTO)
        {
            await _busService.CreateBus(busDTO);
            return new JsonResult(Ok());
        }
        [HttpGet]
        public async Task<IActionResult> GetBus(int id)
        {
            var bus = await _busService.GetBus(id);
            if(bus == null)
            {
                return new JsonResult(NotFound("No bus found with id "+id));
            }
            return new JsonResult(Ok(bus));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBus(int id)
        {
            await _busService.DeleteBus(id);
            
            return new JsonResult(Ok());
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetBuses() 
        {
            var buses = await _busService.GetAllBuses();
            if(!buses.Any())
            {
                return new JsonResult(NotFound("No buses found"));
            }
            return new JsonResult(Ok(buses));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateBus(BusDTO busDTO)
        {
            await _busService.UpdateBus(busDTO);
            
            return new JsonResult(Ok());
        }
    }
}
