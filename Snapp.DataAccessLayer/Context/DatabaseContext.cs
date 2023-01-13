using Microsoft.EntityFrameworkCore;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.DataAccessLayer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<MonthType> MonthTypes { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
