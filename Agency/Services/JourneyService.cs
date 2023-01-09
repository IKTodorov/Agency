using AgencyServices.Contracts;
using AgencyData.DBContext;
using AgencyData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyServices.DTOs;
using AgencyServices.Mappers;

namespace AgencyServices.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly AgencyContext _context;

        public JourneyService(AgencyContext context)
        {
            _context = context;
        }

        public JourneyDTO CreateJourney(JourneyDTO journeyDTO)
        {
            var vehicle = _context.Vehicles.Find(journeyDTO.VehicleId);
            if(vehicle != null)
            {
                var journey = new Journey();
                journey.TakeInfoFrom(journeyDTO);
                _context.Add(journey);
                _context.SaveChanges();
                return journey.ToDTO();
            }
            return null;
        }

        public JourneyDTO DeleteJourney(int id)
        {
            var journey = _context.Journeys.Find(id);
            if(journey != null)
            {
                //Remove all tickets for journey
                _context.Tickets.RemoveRange(_context.Tickets.Where(x => x.JourneyId == id));

                _context.Journeys.Remove(journey);
                _context.SaveChanges();
                return journey.ToDTO();
            }
            return null;
        }

        public List<JourneyDTO> GetAllJourneys()
        {
            var journeys = _context.Journeys.Select(x => x.ToDTO()).ToList();
            return journeys;
        }


        public JourneyDTO GetJourney(int id)
        {
            var journey = _context.Journeys.Find(id);
            if(journey != null)
            {
                return journey.ToDTO();
            }
            return null;
        }

        public JourneyDTO UpdateJourney(int id, JourneyDTO journeyDTO)
        {
            var journey = _context.Journeys.Find(id);
            if (journey != null)
            {
                journey.TakeInfoFrom(journeyDTO);
                _context.SaveChanges();
                return journey.ToDTO();
            }
            return null;
        }
    }
}
