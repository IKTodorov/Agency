using AgencyData.Models;
using AgencyServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Mappers
{
    public static class TicketMapper
    {
        public static TicketDTO ToDTO(this Ticket ticket)
        {
            var ticketDTO = new TicketDTO(ticket.Id, ticket.JourneyId, ticket.AdministrativeCosts);
            return ticketDTO;
        }

        public static Ticket TakeInfoFrom(this Ticket ticket, TicketDTO ticketDTO)
        {
            ticket.Id = ticketDTO.Id;
            ticket.JourneyId = ticketDTO.JourneyId;
            ticket.AdministrativeCosts = ticketDTO.AdministrativeCosts;
            return ticket;
        }
    }
}
