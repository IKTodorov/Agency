using AgencyServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Contracts
{
     public interface ITrainService
    {
        TrainDTO CreateTrain(TrainDTO trainDTO);
        TrainDTO UpdateTrain();
        TrainDTO DeleteTrain();
        TrainDTO GetTrain();
        List<TrainDTO> GetAllTrains();
    }
}
