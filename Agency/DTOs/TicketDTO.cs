namespace AgencyServices.DTOs
{
    public class TicketDTO
    { 
        public TicketDTO(int id, int journeyId, decimal administrativeCosts)
        {
            this.Id = id;
            this.JourneyId = journeyId;
            this.AdministrativeCosts = administrativeCosts;
        }

        public int Id { get; set; }
        public int JourneyId { get; set; }
        public decimal AdministrativeCosts { get; set; }

    }
}
