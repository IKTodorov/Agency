using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyServices.DTOs;

namespace AgencyServices.Contracts
{
     public interface ITicketService
    {
        TicketDTO CreateTicket(TicketDTO ticket);
        TicketDTO UpdateTicket(int id, TicketDTO ticket);
        TicketDTO DeleteTicket(int id);
        TicketDTO GetTicket(int id);
        List<TicketDTO> GetAllTickets();
    }
}
