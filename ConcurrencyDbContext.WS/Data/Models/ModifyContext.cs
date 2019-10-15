using Microsoft.EntityFrameworkCore;

namespace ConcurrencyDbContext.WS.Data.Models
{

    public class ModifyContext : DbContext
    {
        public DbSet<ASD> ASDs { get; set; }

        public ModifyContext(DbContextOptions<ModifyContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ASD>()
                .HasData(
                    new ASD
                    {
                        Id = 1,
                        Content = "HELLO"
                    },
                    new ASD
                    {
                        Id = 2,
                        Content = "WORLD"
                    }
                );
        }
    }
}
