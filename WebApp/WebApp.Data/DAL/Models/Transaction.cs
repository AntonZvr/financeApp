using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Data.DAL.Models;

namespace WebApp.DAL.Models
{
    namespace WebApp.DAL.Models
    {
        public class Transaction
        {
            [Key]
            public int TransactionId { get; set; }
            [ForeignKey("TransactionType")]
            public int Type { get; set; }
            public double Amount { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }

            public TransactionType TransactionType { get; set; }
        }
    }
}
