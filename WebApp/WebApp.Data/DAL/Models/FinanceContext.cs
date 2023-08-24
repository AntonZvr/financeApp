using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.DAL.Models.WebApp.DAL.Models;
using WebApp.Data.DAL.Models;

namespace WebApp.DAL.Models
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options)
        { }

        public DbSet<Transaction> Transactions1 { get; set; }
        public DbSet<TransactionType> TransactionType1 { get; set; }
    }
}
