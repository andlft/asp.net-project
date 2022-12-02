using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<Adress> Adress { get; set; }   
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> Item { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasOne<Adress>(x => x.Adress)
                        .WithOne(x => x.Customer);
            modelBuilder.Entity<Customer>()
                        .HasMany<Order>(x => x.Orders)
                        .WithOne(x => x.Customer);
            modelBuilder.Entity<Order>()
                        .HasMany<Item>(x => x.Items)
                        .WithMany(x => x.Orders);
            base.OnModelCreating(modelBuilder);
        }
    }
}
