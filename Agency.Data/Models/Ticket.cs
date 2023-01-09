using System;
using System.Collections.Generic;

namespace AgencyData.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int JourneyId { get; set; }

    public decimal AdministrativeCosts { get; set; }

    public virtual Journey Journey { get; set; } = null!;
}
