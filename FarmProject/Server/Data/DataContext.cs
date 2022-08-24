using FarmProject.Shared;
using Microsoft.EntityFrameworkCore;

namespace FarmProject.Server.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Quadruped> Quadrupeds { get; set; }
        public DbSet<Fowl> Fowls { get; set; }

        public DbSet<Barn> Barn { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quadruped>().HasData(
                new Quadruped { Id = 1, Name = "porci", Quantity = 5, Corn = 2, Hey = 0, },
                new Quadruped { Id = 2, Name = "oi", Quantity = 0, Corn = null, Hey = null },
                new Quadruped { Id = 3, Name = "bovine", Quantity = 3, Corn = null, Hey = 0.5 },
                new Quadruped { Id = 4, Name = "cai", Quantity = 0, Corn = null, Hey = null }
                );

            modelBuilder.Entity<Fowl>().HasData(
                new Fowl { Id = 1, Name = "gaini", Quantity = 10, Corn = 2, Hey = null },
                new Fowl { Id = 2, Name = "gaste", Quantity = 0, Corn = null, Hey = null },
                new Fowl { Id = 3, Name = "rate", Quantity = 3, Corn = 1, Hey = null },
                new Fowl { Id = 4, Name = "curci", Quantity = 0, Corn = null, Hey = null }
                );

            modelBuilder.Entity<Barn>().HasData(
                new Barn { Id = 1, Name = "porumb", Quantity = 4 },
                new Barn { Id = 2, Name = "fan", Quantity = 6 }
                );



        }

        
            
        



    }
    }

   
