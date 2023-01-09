using AgencyServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Contracts
{
    public interface IJourneyService
    {
        JourneyDTO CreateJourney(JourneyDTO journeyDTO);
        JourneyDTO UpdateJourney(int id, JourneyDTO journeyDTO);
        JourneyDTO DeleteJourney(int id);
        JourneyDTO GetJourney(int id);
        List<JourneyDTO> GetAllJourneys();
    }
}
