using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodjaOmanikud
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CarService primary key (ID)
            modelBuilder.Entity<CarService>()
                .HasKey(cs => cs.Id);

            // CarService relations
            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Car)
                .WithMany()
                .HasForeignKey(cs => cs.CarId);

            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Service)
                .WithMany()
                .HasForeignKey(cs => cs.ServiceId);

            // Payment relations
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.CarService)
                .WithMany()
                .HasForeignKey(p => p.CarServiceId);

            // ServiceBooking relations
            modelBuilder.Entity<ServiceBooking>()
                .HasKey(sb => sb.Id);

            modelBuilder.Entity<ServiceBooking>()
                .HasOne(sb => sb.Car)
                .WithMany()
                .HasForeignKey(sb => sb.CarId);

            modelBuilder.Entity<ServiceBooking>()
                .HasOne(sb => sb.Service)
                .WithMany()
                .HasForeignKey(sb => sb.ServiceId);

            base.OnModelCreating(modelBuilder);
        }
    }

}

