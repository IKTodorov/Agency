using AgencyData.Models;
using AgencyServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDTO ToDTO(this Vehicle vehicle)
        {
            var vehicleDTO = new VehicleDTO(vehicle.PricePerKilometer, vehicle.PassangerCapacity);
            return vehicleDTO;
        }

        public static Vehicle TakeInfoFrom(this Vehicle vehicle, VehicleDTO vehicleDTO)
        {
            //vehicle.Id= vehicleDTO.Id;
            vehicle.PricePerKilometer = vehicleDTO.PricePerKilometer;
            vehicle.PassangerCapacity =vehicleDTO.PassangerCapacity;
            return vehicle;
        }
    }
}
