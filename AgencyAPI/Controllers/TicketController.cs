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
        public TicketController(ITicketService service) { 
            _ticketService= service;
        }

        [HttpPost]
        public JsonResult CreateTicket(TicketDTO ticketDTO)
        {
            var ticket_result = _ticketService.CreateTicket(ticketDTO);
            if(ticket_result == null) 
            {
                return new JsonResult(BadRequest("No such vehicle with id " + ticketDTO.JourneyId));
            }
            return new JsonResult(Ok(ticketDTO));
        }
        [HttpDelete]
        public JsonResult DeleteTicket(int id)
        {
            TicketDTO ticket = _ticketService.DeleteTicket(id);
            if(ticket == null)
            {
                return new JsonResult(NotFound("No ticket with id " + id));
            }
            return new JsonResult(Ok(ticket));
        }
        [HttpGet]
        public JsonResult GetTicket(int id)
        {
            TicketDTO ticket = _ticketService.GetTicket(id);
            if(ticket == null)
            {
                return new JsonResult(NotFound("No ticket with id " + id));
            }
            return new JsonResult(Ok(ticket));
        }
        [HttpGet("GetAll")]
        public JsonResult GetAllTickets()
        {
            List<TicketDTO> tickets = _ticketService.GetAllTickets();
            if(tickets== null)
            {
                return new JsonResult(NotFound("No tickets found"));
            }
            return new JsonResult(tickets);
        }
        
    }
}
