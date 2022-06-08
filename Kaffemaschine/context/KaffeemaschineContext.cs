using Microsoft.EntityFrameworkCore;

namespace Kaffemaschine.context
{
    public class KaffeemaschineContext : DbContext
    {
       public DbSet<Kaffeemaschine> Kaffeemaschinen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Kaffeemaschine.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kaffeemaschine>().ToTable("Kaffeemaschine");
        }
    }
}
