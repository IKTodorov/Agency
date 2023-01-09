
namespace AgencyServices.DTOs
{
    public class JourneyDTO
    {
        public JourneyDTO(int id, int vehicleId, string startLocation, string destination, int distance)
        {
            Id = id;
            VehicleId = vehicleId;
            StartLocation = startLocation;
            Destination = destination;
            Distance = distance;
        }

        public int Id { get; set; }

        public int VehicleId { get; set; }

        public string StartLocation { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public int Distance { get; set; }

    }
}
