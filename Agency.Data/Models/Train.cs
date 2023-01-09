using System;
using System.Collections.Generic;

namespace AgencyData.Models;

public partial class Train
{
    public int Id { get; set; }

    public int Carts { get; set; }

    public int VehicleId { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
