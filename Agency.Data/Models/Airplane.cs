using System;
using System.Collections.Generic;

namespace AgencyData.Models;

public partial class Airplane
{
    public int Id { get; set; }

    public bool HasFreeFood { get; set; }

    public int VehicleId { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
