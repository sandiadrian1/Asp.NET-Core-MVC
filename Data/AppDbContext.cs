using Microsoft.EntityFrameworkCore;
using ParkingMall.Models;

namespace ParkingMall.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Users { get; set; }
        public DbSet<Parkir> Parkir { get; set; }
        public DbSet<TypeTransportasi> TransportationTypes { get; set; }
        public DbSet<DetailParkir> DetailParking { get; set; }
    }
}
