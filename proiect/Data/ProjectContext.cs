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
        public DbSet<OrderItem> orderItems { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to one
            modelBuilder.Entity<User>()
                        .HasOne<Address>(x => x.Address)
                        .WithOne(x => x.User);
            //One to many
            modelBuilder.Entity<User>()
                        .HasMany<Order>(x => x.Orders)
                        .WithOne(x => x.Customer);
            //Many to many
            modelBuilder.Entity<OrderItem>()
                .HasKey(x => new{ x.OrderId, x.ItemId});

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(x => x.order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.item)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ItemId);
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
