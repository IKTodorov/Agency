using System;
using System.Collections.Generic;
using AgencyData.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyData.DBContext;

public partial class AgencyContext : DbContext
{
    public AgencyContext()
    {
    }

    public AgencyContext(DbContextOptions<AgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Journey> Journeys { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Agency;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.HasOne(d => d.Vehicle).WithMany(p => p.Airplanes)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Airplanes_Vehicles");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasOne(d => d.Vehicle).WithMany(p => p.Buses)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buses_Vehicles");
        });

        modelBuilder.Entity<Journey>(entity =>
        {
            entity.HasOne(d => d.Vehicle).WithMany(p => p.Journeys)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journeys_Vehicles");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.AdministrativeCosts).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Journey).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.JourneyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Journeys");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasOne(d => d.Vehicle).WithMany(p => p.Trains)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trains_Vehicles");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.PricePerKilometer).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
