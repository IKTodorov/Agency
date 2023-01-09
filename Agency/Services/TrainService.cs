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
    public class TrainService : ITrainService
    {
        private readonly AgencyContext _context;

        public TrainService(AgencyContext context)
        {
            _context = context;
        }
        public TrainDTO CreateTrain(TrainDTO trainDTO)
        {
            ////var vehicle = new Vehicle();
            ////vehicle.TakeInfoFrom(trainDTO.Vehicle);
            ////_context.Vehicles.Add(vehicle);
            var train = new Train();
            train.TakeInfoFrom(trainDTO);
            _context.Trains.Add(train);
            _context.SaveChanges();
            return train.ToDTO();
        }

        public TrainDTO DeleteTrain()
        {
            throw new NotImplementedException();
        }

        List<TrainDTO> ITrainService.GetAllTrains()
        {
            throw new NotImplementedException();
        }

        TrainDTO ITrainService.GetTrain()
        {
            throw new NotImplementedException();
        }

        TrainDTO ITrainService.UpdateTrain()
        {
            throw new NotImplementedException();
        }
    }
}
