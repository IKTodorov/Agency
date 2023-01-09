namespace AgencyServices.DTOs
{
    public class VehicleDTO
    {
        public VehicleDTO(decimal pricePerKilometer, int passangerCapacity)
        {
            //Id = id;
            PricePerKilometer = pricePerKilometer;
            PassangerCapacity = passangerCapacity;
        }

        //public int Id { get; set; }

        public decimal PricePerKilometer { get; set; }

        public int PassangerCapacity { get; set; }
    }
}
