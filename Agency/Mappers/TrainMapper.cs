using AgencyData.Models;
using AgencyServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Mappers
{
    public static class TrainMapper
    {
        public static TrainDTO ToDTO(this Train train)
        {
            var trainDTO = new TrainDTO(train.Id, train.Carts, train.Vehicle.ToDTO());
            return trainDTO;
        }
        public static Train TakeInfoFrom(this Train train, TrainDTO trainDTO) 
        {
            var vehicle = new Vehicle();
            vehicle.TakeInfoFrom(trainDTO.Vehicle);
            train.Id= trainDTO.Id;
            //train.VehicleId= trainDTO.VehicleId;
            train.Carts= trainDTO.Carts;
            train.Vehicle = vehicle;
            return train;
        }
    }
}
