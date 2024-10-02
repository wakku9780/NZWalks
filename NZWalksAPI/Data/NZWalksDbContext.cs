using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext:DbContext
    {

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulty
            var difficulties = new List<Difficulty>()
    {
        new Difficulty()
        {
            Id = Guid.Parse("cdb28247-441e-4301-80df-1f19d6ad8849"),
            Name = "Easy"
        },
        new Difficulty()
        {
            Id = Guid.Parse("cdb28247-441e-4301-80df-1f19d6ad8850"),
            Name = "Medium"
        },
        new Difficulty()
        {
            Id = Guid.Parse("cdb28247-441e-4301-80df-1f19d6ad8749"),
            Name = "Hard"
        }
    };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
    {
        new Region
        {
            Id = Guid.Parse("a1e28247-441e-4301-80df-1f19d6ad8749"), // Changed GUID
            Name = "Auckland",
            Code = "AKL",
            RegionImageUrl = "wwwwww"
        },
        new Region
        {
            Id = Guid.Parse("b1e28247-441e-4301-80df-1f19d6ad8749"), // Changed GUID
            Name = "Wellington",
            Code = "WKL",
            RegionImageUrl = "wwwwww"
        },
        new Region
        {
            Id = Guid.Parse("c1e28247-441e-4301-80df-1f19d6ad8749"), // Changed GUID
            Name = "Mubarakpur",
            Code = "M.P",
            RegionImageUrl = "wwwwww"
        }
    };

            // Seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }


    }


}
