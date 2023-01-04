using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<Address> Address { get; set; }   
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasOne<Address>(x => x.Address)
                        .WithOne(x => x.User);
            modelBuilder.Entity<User>()
                        .HasMany<Order>(x => x.Orders)
                        .WithOne(x => x.Customer);
            modelBuilder.Entity<Order>()
                        .HasMany<Item>(x => x.Items)
                        .WithMany(x => x.Orders);
            base.OnModelCreating(modelBuilder);
        }
    }
}
