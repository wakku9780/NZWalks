using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        private readonly DbContextOptions options;

        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);

            var readerRoleId = "a7155d6-99d7-4123-gkjg56-1218ecb98e3e";
            var writerRoleId = "a7155d6-99d7-4123-gkjg56-1219ecb98e3e";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",

                    NormalizedName="Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id=writerRoleId,
                    ConcurrencyStamp=writerRoleId,

                    Name="Writer",

                    NormalizedName="Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
  