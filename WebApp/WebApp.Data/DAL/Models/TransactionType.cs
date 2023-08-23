using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.DAL.Models
{
    public class TransactionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
