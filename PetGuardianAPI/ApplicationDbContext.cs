using Microsoft.EntityFrameworkCore;
using PetGuardianAPI.Entidades;

namespace PetGuardianAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<animales>().HasKey(x => new 
        //    {
        //        x.id
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<vacunas> vacunas { get; set; }
        public DbSet<adoptantes> adoptantes { get; set; }
        public DbSet<tipoAnimal> tipoAnimal { get; set; }
        public DbSet<fundaciones> fundaciones { get; set; }
        public DbSet<animales> animales { get; set; }
    }
}
