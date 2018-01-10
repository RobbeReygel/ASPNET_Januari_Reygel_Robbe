using ASPNET_Januari_Reygel_Robbe.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Januari_Reygel_Robbe.Data
{
    public interface IEntityContext
    {
        DbSet<Owner> Owners { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Type> Type { get; set; }
    }

    public class EntityContext : DbContext, IEntityContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasKey(b => b.Id);
            modelBuilder.Entity<Car>().HasOne(b => b.Owner).WithMany(ba => ba.Cars);
            modelBuilder.Entity<Car>().HasOne(b => b.Type).WithMany(g => g.Cars);

            modelBuilder.Entity<Owner>().HasKey(a => a.Id);
            modelBuilder.Entity<Owner>().HasMany(b => b.Cars).WithOne(ba => ba.Owner);


            modelBuilder.Entity<Type>().HasKey(b => b.Id);

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Type> Type { get; set; }
    }

}
