using Microsoft.EntityFrameworkCore;

namespace ConcurrencyDbContext.WS.Data.Models
{
    public class QueryContext : DbContext
    {
        public DbSet<TestTable> TestTables { get; set; }
        public QueryContext(DbContextOptions<QueryContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestTable>().HasNoKey();
        }
    }
}
