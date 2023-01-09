using System;
using System.Collections.Generic;

namespace AgencyData.Models;

public partial class Journey
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public string StartLocation { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int Distance { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual Vehicle Vehicle { get; set; } = null!;
}
