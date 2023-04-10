using InfiGrowth.Entity.Manage;
using Microsoft.EntityFrameworkCore;
using Skyttus.Core.Infra.Context;

namespace InfiGrowth.Infra.Context
{
    public class InfiGrowthContext : SkyttusBaseContext
    {
        public InfiGrowthContext(DbContextOptions<InfiGrowthContext> options) : base(options)
        {

        }

     
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }
        public DbSet<TransactionReports> TransactionReports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
