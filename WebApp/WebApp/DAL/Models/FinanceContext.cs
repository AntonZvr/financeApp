using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApp.DAL.Models
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
