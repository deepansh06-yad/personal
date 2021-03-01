using MecPark.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Database
{
    public class MecParkDbContext: DbContext
    {
        public MecParkDbContext(DbContextOptions<MecParkDbContext> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<AllocationManager> AllocationManagers { get; set; }
        public DbSet<ParkingManager> ParkingManagers { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingHistory> ParkingHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Space>()
                .HasOne(s => s.Garage)
                .WithMany(g => g.Spaces);
            modelBuilder.Entity<Space>()
                .HasOne(s => s.AllocationManager)
                .WithMany(a => a.Spaces);
            modelBuilder.Entity<Garage>()
                .HasOne(g => g.ParkingManager);
            modelBuilder.Entity<Parking>()
                .HasOne(p => p.User);
        }
    }
}
