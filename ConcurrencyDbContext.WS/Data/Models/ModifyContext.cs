using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcurrencyDbContext.WS.Data.Models
{
    public class TestTable
    {
        public string Content1 { get; set; }
        public string Content2 { get; set; }
    }

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
    [Table("ASD", Schema = "dbo")]
    public class ASD
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }

    public class ModifyContext : DbContext
    {
        public DbSet<ASD> ASDs { get; set; }

        public ModifyContext(DbContextOptions<ModifyContext> options) :
            base(options)
        {

        }
    }
}
