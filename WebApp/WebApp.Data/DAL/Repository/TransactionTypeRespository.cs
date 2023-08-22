using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void DeleteTransactionType(int transactionTypeId)
        {
            TransactionType transactionType = _context.TransactionType1.Find(transactionTypeId);
            _context.TransactionType1.Remove(transactionType);
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
