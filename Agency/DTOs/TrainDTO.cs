using AgencyData.Models;

namespace AgencyServices.DTOs
{
    public class TrainDTO
    {
        public TrainDTO(int id, int carts, VehicleDTO vehicle)
        {
            Id = id;
            //VehicleId = vehicleId;
            Carts = carts;
            Vehicle = vehicle;
        }

        public int Id { get; set; }

        public int Carts { get; set; }

        //public int VehicleId { get; set; }

        public virtual VehicleDTO Vehicle { get; set; } = null!;
    }
}
