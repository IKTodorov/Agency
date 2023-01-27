using AgencyData.Models;
using AgencyServices.Contracts;
using AgencyServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService service)
        {
            _ticketService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketDTO ticketDTO)
        {
            await _ticketService.CreateTicket(ticketDTO);
            return new JsonResult(Ok());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _ticketService.DeleteTicket(id);

            return new JsonResult(Ok());

        }
        [HttpGet]
        public async Task<IActionResult> GetTicket(int id)
        {
            TicketDTO ticket = await _ticketService.GetTicket(id);
            if (ticket == null)
            {
                return new JsonResult(NotFound("No ticket with id " + id));
            }
            return new JsonResult(Ok(ticket));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            if (!tickets.Any())
            {
                return new JsonResult(NotFound("No tickets found"));
            }
            return new JsonResult(tickets);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateTicket(TicketDTO ticket)
        {
            await _ticketService.UpdateTicket(ticket);
            return new JsonResult(Ok());
        }

    }
}
