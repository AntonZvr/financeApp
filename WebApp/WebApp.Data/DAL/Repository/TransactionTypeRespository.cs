using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;
using WebApp.Data.DAL.Models;
using WebApp.Data.DAL.RepositoryInterfaces;

namespace WebApp.Data.DAL.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly FinanceContext _context;

        public TransactionTypeRepository(FinanceContext context)
        {
            _context = context;
        }

        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return _context.TransactionType1.ToList();
        }

        public TransactionType GetTransactionTypeById(int id)
        {
            return _context.TransactionType1.Find(id);
        }

        public void InsertTransactionType(TransactionType transactionType)
        {
            _context.TransactionType1.Add(transactionType);
        }

        public bool DeleteTransactionType(int transactionTypeId)
        {  
            bool existTransactionsWithThisType = _context.Transactions1.Any(t => t.Type == transactionTypeId);

            if (existTransactionsWithThisType)
            {
                return false;  
            }

            TransactionType transactionType = _context.TransactionType1.Find(transactionTypeId);
            _context.TransactionType1.Remove(transactionType);

            _context.SaveChanges(); 

            return true; 
        }


        public void UpdateTransactionType(TransactionType transactionType)
        {
            _context.Entry(transactionType).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool TransactionTypeExists(int id)
        {
            return _context.TransactionType1.Any(e => e.Id == id);
        }
    }

}
