using AgencyData.DBContext;
using AgencyData.Models;
using AgencyServices.Contracts;
using AgencyServices.DTOs;
using AgencyServices.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Services
{
    public class TicketService : ITicketService
    {
        private readonly AgencyContext _context;

        public TicketService(AgencyContext context)
        {
            _context = context;
        }
        public TicketDTO CreateTicket(TicketDTO ticketDTO)
        {
            var journey = _context.Journeys.Find(ticketDTO.JourneyId);
            if(journey != null)
            {
                var ticket = new Ticket();
                ticket.TakeInfoFrom(ticketDTO);
                _context.Add(ticket);
                _context.SaveChanges();
                return ticket.ToDTO();
            }
            return null;
        }

        public TicketDTO DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if(ticket != null)
            {
                _context.Remove(ticket);
                _context.SaveChanges();
                return ticket.ToDTO();
            }
            return null;
        }

        public List<TicketDTO> GetAllTickets()
        {
            var tickets = _context.Tickets.Select(x => x.ToDTO()).ToList();
            return tickets;
        }

        public TicketDTO GetTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket != null)
            {
                return ticket.ToDTO();
            }
            return null;
        }

        public TicketDTO UpdateTicket(int id, TicketDTO ticketDTO)
        {
            var ticket = _context.Tickets.Find(id);
            if(ticket != null )
            {
                ticket.TakeInfoFrom(ticketDTO);
                _context.SaveChanges();
                return ticket.ToDTO();
            }
            return null;
        }
    }
}
