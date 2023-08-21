using System.ComponentModel.DataAnnotations;

namespace WebApp.DAL.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }

}
