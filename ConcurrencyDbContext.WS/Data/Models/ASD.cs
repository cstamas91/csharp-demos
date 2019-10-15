using System.ComponentModel.DataAnnotations.Schema;

namespace ConcurrencyDbContext.WS.Data.Models
{
    [Table("ASD", Schema = "dbo")]
    public class ASD
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
