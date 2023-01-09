using AgencyServices.DTOs;
using AgencyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Mappers
{
    public static class JourneyMapper
    {
        public static JourneyDTO ToDTO(this Journey journey)
        {
            var journeyDTO = new JourneyDTO(journey.Id, journey.VehicleId, journey.StartLocation, journey.Destination, journey.Distance);
            return journeyDTO;
        }

        public static Journey TakeInfoFrom(this Journey journey, JourneyDTO journeyDTO) 
        {
            journey.Id = journeyDTO.Id;
            journey.VehicleId = journeyDTO.VehicleId;
            journey.StartLocation = journeyDTO.StartLocation;
            journey.Destination = journeyDTO.Destination;
            journey.Distance = journeyDTO.Distance;

            return journey;

        }
    }
}
