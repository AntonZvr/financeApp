using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;
using WebApp.DAL.Models.WebApp.DAL.Models;
using WebApp.DAL.RepositoryInterfaces;

namespace WebApp.DAL.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinanceContext _context;

        public TransactionRepository(FinanceContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> GetTransactions()
        {
            return _context.Transactions1.AsQueryable();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions1.Find(transactionId);
        }

        public void InsertTransaction(Transaction transaction)
        {
            _context.Transactions1.Add(transaction);
        }

        public void DeleteTransaction(int transactionId)
        {
            Transaction transaction = _context.Transactions1.Find(transactionId);
            _context.Transactions1.Remove(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
