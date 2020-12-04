
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ComplexStore.DataModel.Model
{
    public class ComplexStoreDbContext : DbContext
    {
        // constructor
        public ComplexStoreDbContext(DbContextOptions<ComplexStoreDbContext> options):base(options)
        {       
        }


        // 1 dbset -> classes rep tables
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }


        // 2 onModelCreating override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Location>(entity =>
            {
                // property
                entity.Property(e => e.Name).HasMaxLength(20);
                // constraint
                entity.HasCheckConstraint(name: "CK_Location_Stock_Positive", sql: "[Stock] > 0");             
            });
            modelBuilder.Entity<Order>(entity =>
            {
                // relationship
                // configure manually just to be safe, the convention should discover it 
                // two navigation properties and a foreign key all together
                entity.HasOne(o => o.StoreLocation).WithMany(l => l.Orders).HasForeignKey(o => o.LocationId)
                                .OnDelete(DeleteBehavior.Cascade).IsRequired();

                // if a FK is not explicted written, a shadow property is generated
                // will still work, but won't be able to access the FK property

                entity.HasCheckConstraint("CK_Order_Quantity_Positive", "[Quantity] > 0");
                // hasindex isunique
            });
        }
    }
}
