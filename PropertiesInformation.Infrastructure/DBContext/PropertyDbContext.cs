using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Entities;
using System.Diagnostics.CodeAnalysis;


namespace PropertiesInformation.Infrastructure.DBContext
{
    [ExcludeFromCodeCoverage]
    public class PropertyDbContext: DbContext
    {
        public PropertyDbContext(DbContextOptions options) : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(c => c.Properties)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.IdOwner);

            modelBuilder.Entity<Property>()
                .HasMany(c => c.PropertyImages)
                .WithOne(c => c.Property)
                .HasForeignKey(c => c.IdProperty);

            modelBuilder.Entity<Property>()
                .HasMany(c => c.PropertyTraces)
                .WithOne(c => c.Property)
                .HasForeignKey(c => c.IdProperty);

            modelBuilder.Entity<User>().HasData(new User {IdUser = 1, UserName = "Test", Password = "Test" });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
