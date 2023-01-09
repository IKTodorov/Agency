using System;
using System.Collections.Generic;

namespace AgencyData.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public decimal PricePerKilometer { get; set; }

    public int PassangerCapacity { get; set; }

    public virtual ICollection<Airplane> Airplanes { get; } = new List<Airplane>();

    public virtual ICollection<Bus> Buses { get; } = new List<Bus>();

    public virtual ICollection<Journey> Journeys { get; } = new List<Journey>();

    public virtual ICollection<Train> Trains { get; } = new List<Train>();
}
