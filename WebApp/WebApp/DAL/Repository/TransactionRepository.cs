using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;
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

        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.Find(transactionId);
        }

        public void InsertTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void DeleteTransaction(int transactionId)
        {
            Transaction transaction = _context.Transactions.Find(transactionId);
            _context.Transactions.Remove(transaction);
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
